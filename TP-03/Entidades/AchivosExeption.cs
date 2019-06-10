﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ArchivosException : Exception
    {
        public ArchivosException(Exception innerException) : base(" Se produjo un error durante la manipulación de archivos. ", innerException)
        {

        }
    }
}
