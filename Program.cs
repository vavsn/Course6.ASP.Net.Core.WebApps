using System;
using System.Threading.Tasks;

namespace PostRequest
{
    class Program
    {

        static async Task Main(string[] args)
        {
            await Task.Run(()=>myGetRequest());
        }

        static async Task<int> myGetRequest()
        {
            Console.WriteLine("Start my prog");

            var mCont = new myController();

            var dataRes = new RequestDTO();
            for (int i= mCont.startPost; i<= mCont.endPost; i++)
            {
                dataRes = await mCont.GetId(i);
                if (dataRes != null)
                {
                    mCont.writeResponse(dataRes);
                }
            }
            Console.WriteLine("End my prog");

            return 1;
        }
    }
}
