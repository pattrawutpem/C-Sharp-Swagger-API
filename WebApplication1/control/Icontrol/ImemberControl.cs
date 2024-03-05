using System.Collections.Generic;
using WebApplication1.control.veiwModel;
using WebApplication1.Models;


namespace WebApplication1.control.Icontrol
{
    public interface ImemberControl
    {
        Task<bool> addMember(MemberViewModel model);
        Task<bool> updateMem(MemberViewModel model);
        Task<List<Member>> getAllMem();
        Task<Member> getMemById(int Id);
        Task<List<ListMember>> getMemByIdJoin(int Id);
        Task<List<ListMember>> getJoinAll();
        Task<List<ListMember>> getRLjoin();
        Task<bool> deleteMem(int Id);
        Task<List<Member>> addBulk(string MemberTypeCode);
        Task<List<Member>> updateBulk(string MemberTypeCode);
        Task<List<Member>> deleteBulk(string MemberTypeCode);
    }
}
