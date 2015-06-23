#region Copyright 2009 Robert Konklewski

/*
 * CursesSharp
 * 
 * Copyright 2009 Robert Konklewski
 * 
 * This library is free software; you can redistribute it and/or modify it
 * under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation; either version 3 of the License, or (at your
 * option) any later version.
 *
 * This library is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
 * FITNESS FOR A PARTICULAR PURPOSE.  See the GNU Lesser General Public
 * License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * www.gnu.org/licenses/>.
 * 
 */

#endregion

using System;

namespace CursesSharp
{
    public class CursesException : Exception
    {
        public CursesException()
        {
        }

        public CursesException(string message)
            : base(message)
        {
        }

        public CursesException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
