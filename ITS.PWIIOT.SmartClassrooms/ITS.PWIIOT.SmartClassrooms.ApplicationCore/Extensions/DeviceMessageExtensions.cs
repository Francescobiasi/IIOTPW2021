﻿using ITS.PWIIOT.SmartClassrooms.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.ApplicationCore.Extensions
{
    public static class DeviceMessageExtensions
    {
        public static DeviceMessage ToDeviceMessage(this Lesson lesson, string microcontrollerId, MessageOperation messageOperation)
        {
            return new DeviceMessage
            {
                LessonId = lesson.Id.ToString(),
                Duration = lesson.GetDuration(),
                StartDate = lesson.StartDate,
                MicrocontrollerId = microcontrollerId,
                Operation = messageOperation,
                Subject = lesson.Subject.Name,
                Teacher = lesson.Teacher.GetFullName()
            };
        }
    }
}