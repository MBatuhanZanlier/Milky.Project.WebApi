﻿namespace MilkyProject.WebUI.Dtos.AdressDtos
{
    public class UpdateAdressDto
    {
        public int AdressId { get; set; }
        public string Street { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string BusinessHoursWeek { get; set; }
        public string BusinessHoursWeekend { get; set; }
    }
}
