﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace savichev21pr.Models
{
    public class Document
    {
        public int id {  get; set; }
        public string src { get; set; }
        public string name { get; set; }
        public string user { get; set; }
        public int id_document { get; set; }
        public DateTime date { get; set; }
        public int status { get; set; }
        public string vector { get; set; }
    }
}
