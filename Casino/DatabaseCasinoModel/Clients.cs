using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCasinoModel
{
    public partial class Clients : IEquatable<Clients>
    {
        public bool Equals(Clients other)
        {
            if (this.Id != other.Id) return false;
            if (this.Name != other.Name) return false;
            if (this.Surname != other.Surname) return false;
            if (this.DateOfBirth != other.DateOfBirth) return false;
            return true;
        }
    }
}
