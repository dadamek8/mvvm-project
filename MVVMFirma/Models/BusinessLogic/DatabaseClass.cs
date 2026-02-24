using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class DatabaseClass
    {
        #region Contex
        public SklepEntities db { get; set; }
        #endregion
        #region Constructor
        public DatabaseClass(SklepEntities db)
        {
            this.db = db;
        }
        #endregion
    }
}
