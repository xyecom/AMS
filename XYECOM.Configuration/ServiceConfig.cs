using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Configuration
{
    public class ServiceConfig : BaseConfig
    {
        private static ServiceConfigInfo instance = null;

        public static ServiceConfigInfo Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockHelper)
                    {
                        instance = new ServiceConfigInfo();
                    }
                }
                return instance;
            }
        }

        protected override void Init()
        {
            //throw new NotImplementedException();
        }

        public override bool Update()
        {
            //throw new NotImplementedException();
            return false;
        }
    }
}
