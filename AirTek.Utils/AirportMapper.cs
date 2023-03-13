using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTek.Utils
{
    public class AirportMapper
    {
        private Dictionary<string, string> _fakeSourceOfTruth;
        public AirportMapper()
        {
            _fakeSourceOfTruth = new Dictionary<string, string>();
            _fakeSourceOfTruth.Add("XYZ", "Toronto");
            _fakeSourceOfTruth.Add("YUL", "Montreal");
            _fakeSourceOfTruth.Add("YYC", "Calgary");
            _fakeSourceOfTruth.Add("YVR", "Vancouver");
        }
        public string GetAiportByCode(string code)
        {
            if (!string.IsNullOrEmpty(code))
                return _fakeSourceOfTruth[code.ToUpper()];
            return "";
        }

        public void AddMoreAirports(string code, string desc)
        {
            _fakeSourceOfTruth.Add(code, desc);
        }
    }
}
