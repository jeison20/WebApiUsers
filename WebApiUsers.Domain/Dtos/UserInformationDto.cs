﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiUsers.Domain.Dtos
{
    public class UserInformationDto
    {
        public int Id { get; set; }       
        public string Document { get; set; }        
        public string Name { get; set; }       
        public string Email { get; set; }       
        public string Password { get; set; }
    }
}
