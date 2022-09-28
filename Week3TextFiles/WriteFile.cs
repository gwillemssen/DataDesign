using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3TextFiles
{
    internal static class WriteFile
    {
        //method to write results of fights to doubly linked list
        public static void WriteResult(DoublyList _doublyList)
        {
            //place for result file to go
            string path = $@"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName}\Results.txt";
            //if a results file already exists, delete it
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            //create a streamwriter
            using (StreamWriter sw = new StreamWriter(path))
            {
                //while there are items in the doubly linked list, write them to result file
                while (_doublyList != null)
                {
                    sw.WriteLine(_doublyList.Result);
                    _doublyList = _doublyList.Next;
                }

                //dispose of and close the streamwriter
                sw.Dispose();
                sw.Close();
            }
        }
    }
}
