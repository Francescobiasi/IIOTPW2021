﻿using ITS.PWIIOT.SmartClassrooms.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.ApplicationCore.Extensions
{
    public static class ClassroomExtensions
    {
        public static ClassroomInfo ToClassroomInfo(this Domain.Classroom classroom)
        {
            return new ClassroomInfo
            {
                Name = classroom.GetClassroomId()
            };
        }
    }
}