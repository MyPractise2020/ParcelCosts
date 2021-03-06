﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryCosts
{
    public class Parcel
    {
        public int Id { get; set; }

        public decimal Height { get; set; }

        public decimal Width { get; set; }

        public decimal Length { get; set; }

        public decimal Cost { get; set; }

        public ParcelSize Type { get; set; }

        public decimal Weight { get; set; }

        public bool IsOverweight { get; set; }

    }
}
