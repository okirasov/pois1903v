using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIServer.Interfaces
{
    public interface IBaseService<DTO>
    {
        Task<List<DTO>> Get();
        Task<DTO> Get(int id);
        Task<bool> Delete(int id);
        Task<bool> Create(DTO dto);
        Task<bool> Update(int id, DTO dto);

        bool IsExist(int id);

    }
}
