using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ScreenLocker
{
    class LockManager
    {
        public readonly String LockFile = Path.GetTempPath() + "ScreenLocker.lck";

        public bool AcquireLock()
        {
            if (!File.Exists(LockFile))
            {
                try
                {
                    using (File.Create(LockFile))
                    {
                        return true;
                    }
                }
                catch
                {
                }
            }

            return false;
        }

        public void ReleaseLock()
        {
            if (File.Exists(LockFile))
            {
                try
                {
                    File.Delete(LockFile);
                }
                catch
                {
                }
            }
        }
    }
}
