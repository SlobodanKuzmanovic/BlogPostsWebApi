using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class Scope
    {
        private static IFactory _factory;

        public static IFactory Factory
        {
            get { return _factory; }
            set
            {
                _factory = value;
                DataAccessLayer.Scope.Factory = new DataAccessLayer.Factory();
            }
        }
    }
}
