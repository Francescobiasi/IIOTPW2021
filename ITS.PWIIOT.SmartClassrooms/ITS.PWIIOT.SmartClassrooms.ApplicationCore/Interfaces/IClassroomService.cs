﻿using ITS.PWIIOT.SmartClassrooms.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces
{
    public interface IClassroomService
    {
        Task SetClassroomAvailable(string classroomId);
        Task<ClassroomInfo> GetClassroomById(string classroomId);
    }
}
