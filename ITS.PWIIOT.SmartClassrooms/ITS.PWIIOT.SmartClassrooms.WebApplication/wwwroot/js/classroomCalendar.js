
const classroom = document.getElementById("classroomId");
const params = { classroomId: classroom.value }
const url = '/calendar'
var calendarEl = document.getElementById('calendar');

document.addEventListener('DOMContentLoaded', function () {
    var calendar = BuildCalendar(calendarEl, params, url);
    calendar.render();
});

 function BuildCalendar(calendarEl, params, url) {
    return new FullCalendar.Calendar(calendarEl, {
        initialView: 'timeGridDay',
        headerToolbar: {

            left: 'prev,next,today',
            right: 'dayGridMonth,timeGridWeek,timeGridDay',
            center: 'title',
        },
        selectable: true,
        dateClick: function (info) {
        },
        select: function (info) {
            $('#addEventModal').modal('show');
            var startDate = document.getElementById("startDate");
            var endDate = document.getElementById("endDate");
            startDate.value = info.startStr;
            endDate.value = info.endStr;
        },
        eventDidMount: function (info) {
            $(info.el).find(".fc-event-main").prepend("<span class='closeon test'>X</span>");
            $(info.el).find(".closeon").click(function () {
                fetch(url + '?lessonId=' + info.event.id, {
                    method: 'DELETE',
                })
                info.event.remove();
            });
        },
        locale: 'it',
        slotMinTime: '08:00',
        slotMaxTime: '21:00',
        expandRows: true,

        events: {
            url: url,
            method: 'GET',
            extraParams: params,
            failure: function () {
                alert('there was an error while fetching events!');
            },

        },

        allDaySlot: false,

        initialView: 'timeGridWeek',
        timeZone: 'UTC',
        themeSystem: 'bootstrap',
        locale: 'it',

        hiddenDays: [0, 6]
    });
}
