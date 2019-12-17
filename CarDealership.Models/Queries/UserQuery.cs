﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.Models.Queries
{
    public class UserQuery
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
