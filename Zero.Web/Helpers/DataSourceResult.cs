﻿using System.Collections;

namespace Zero.Web.Helpers
{
    public class DataSourceResult
    {
        public object ExtraData { get; set; }
        public IEnumerable Data { get; set; }
        public object Errors { get; set; }
        public int Total { get; set; }
    }
}