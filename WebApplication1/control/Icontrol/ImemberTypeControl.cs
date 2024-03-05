using WebApplication1.control.veiwModel;
using WebApplication1.Models;

namespace WebApplication1.control.Icontrol
{
    public interface ImemberTypeControl
    {
        Task<bool> add(MemberTypeViewModel model); //เพิ่มข้อมูล
        Task<bool> updateData(MemberTypeViewModel model);
        Task<List<MemberType>> getAll();
        Task<MemberType> getById(string memberTypeCode);
        Task<bool> deleteData(string memberTypeCode);
    }
    
}
