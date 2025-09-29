using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    class FileDownloader
    {
        public event Action<int> ProgressChanged;

        public void Download()
        {
            for (int i = 0; i <= 100; i += 10)
            {
                Thread.Sleep(100);
                ProgressChanged?.Invoke(i);
            }
        }
    }

}
