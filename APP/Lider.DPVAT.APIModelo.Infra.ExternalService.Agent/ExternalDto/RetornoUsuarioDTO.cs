using System.Collections.Generic;

namespace Lider.DPVAT.MODELO.ExternalService.Agent.ExternalDto
{
    public class RetornoUsuarioDTO
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public List<string> DataArray1 { get; set; }
        public List<string> DataArray2 { get; set; }
        public List<string> DataArray3 { get; set; }
        public List<string> DataArray4 { get; set; }
        public List<string> DataArray5 { get; set; }
        public string DataFile { get; set; }
    }
}
