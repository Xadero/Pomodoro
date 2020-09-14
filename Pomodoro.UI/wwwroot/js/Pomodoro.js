var Pomodoro = (function () {
    var self = {};

    self.GetUserPomodoroTypes = function (userId) {
        var dropdown = $('#types');
        dropdown.empty();

        $.getJSON('https://localhost:5001/Pomodoros/GetPomodoroType/' + userId, function (data) {
            $.each(data, function (key, entry) {
                dropdown.append($('<option id="' + entry.typeId + '"></option>').attr('value', entry.id).text(entry.value));
            })
        });
    };

    self.GetUserSettings = function (userId, pomodoroMinutes, breakMinutes) {
        $.getJSON('https://localhost:5001/Pomodoros/GetUserSettings/' + userId, function (data) {
            settings = data;
            pomodoroMinutes.innerText = settings.pomodoroDuration;
            breakMinutes.innerText = settings.breakDuration;
        });
    };

    self.GetUserById = function (userId) {
        $.getJSON('https://localhost:5001/Users/' + userId, function (data) {
            user = data;
        });
    };

    self.GetUserStatistics = function (userId, range) {
        $.getJSON('https://localhost:5001/Pomodoros/GetUserStatistics/' + userId + '/' + range, function (data) {
            $("#total").text(data.total);
            $("#completed").text(data.completed);
            $("#canceled").text(data.canceled);
        });
    };

    self.GetHistory = function (userId) {
        $.getJSON('https://localhost:5001/Pomodoros/GetUserHistory/' + userId, function (data) {
            $.each(data, function (i, item) {
                var $tr = $('<tr>').append(
                    $('<td>').text(item.startDate.substr(0, 19).replace("T", " ")),
                    $('<td>').text(item.pomodoroDuration),
                    $('<td>').text(item.breakDuration),
                    $('<td>').text(item.notes),
                    $('<td>').text(item.pomodoroType.value),
                    $('<td>').text(item.pomodoroStatus.value),
                );
                $("#history").append($tr);
            });
        });
    };

    self.StopInterval = function (startTimer) {
        clearInterval(startTimer);
    };

    self.AddNewPomodoroType = function (userId, value) {
        if (value === '') {
            alert("Enter new type..");
            return;
        };

        $.ajax({
            url: 'https://localhost:5001/Pomodoros/AddNewPomodoroType/',
            type: 'POST',
            dataType: 'json',
            contentType: 'application/json',
            data: JSON.stringify({ pomodoroUserId: userId, value: value }),
            success: function (data) {
                Pomodoro().GetUserPomodoroTypes(user.userId);
                alert("Added type: " + value);
            },
            error: function (data) {
                alert("Error occured");
            }
        });
    };

    self.UpdateSettings = function (userId, pomodoroMinutes, breakMinutes) {
        if (pomodoroMinutes === '' || pomodoroMinutes == 0 || breakMinutes === '' || breakMinutes == 0) {
            alert("Pomodoro duration and break duration values must be greater than 0");
            return;
        }

        $.ajax({
            url: 'https://localhost:5001/Pomodoros/UpdateSettings/',
            type: 'PUT',
            dataType: 'json',
            contentType: 'application/json',
            data: JSON.stringify({ pomodoroUserId: userId, pomodoroDuration: parseInt(pomodoroMinutes), breakDuration: parseInt(breakMinutes) }),
            success: function (data) {
                settings = data;
                $("#p_minutes").text(data.pomodoroDuration);
                $("#b_minutes").text(data.breakDuration);
                alert("Settings updated");
            },
            error: function (data) {
                alert("Error occured");
            }
        });
    };

    self.CreateNewPomodoro = function (pomodoro) {
        $.ajax({
            url: 'https://localhost:5001/Pomodoros/CreateNewPomodoro/',
            type: 'POST',
            dataType: 'json',
            contentType: 'application/json',
            data: JSON.stringify({ pomodoroUserId: pomodoro.PomodoroUserId, pomodoroDuration: pomodoro.PomodoroDuration, breakDuration: pomodoro.BreakDuration, notes: pomodoro.Notes, pomodoroTypeId: pomodoro.TypeId }),
            success: function (data) {
                pomodoro.PomodoroId = data.pomodoroId;
            },
            error: function (data) {
                alert("Error occured");
            }
        });
    };

    self.CompletePomodoro = function (id) {
        $.ajax({
            url: 'https://localhost:5001/Pomodoros/CompletePomodoro/' + id,
            type: 'PUT',
            dataType: 'json',
            contentType: 'application/json',
        });
    };

    self.CancelPomodoro = function (id) {
        $.ajax({
            url: 'https://localhost:5001/Pomodoros/CancelPomodoro/' + id,
            type: 'PUT',
            dataType: 'json',
            contentType: 'application/json',
        });
    };

    return self;
});