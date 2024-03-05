using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Reflection;
using WebApplication1.control.Icontrol;
using WebApplication1.control.veiwModel;
using WebApplication1.Models;

namespace WebApplication1.control.controls
{
    public class memberControl : ImemberControl
    {
        private readonly DemoDbContext _DemoDbContext;

        public memberControl(DemoDbContext demoDbContext)
        {
            _DemoDbContext = demoDbContext;
        }

        public async Task<bool> addMember(MemberViewModel model)
        {
            //throw new NotImplementedException();
            var addmems = new Member();
                addmems.Id = model.Id;
                addmems.MemberTypeCode = model.MemberTypeCode;
                addmems.MemberName = model.MemberName;
                addmems.Mobile = model.Mobile;
                addmems.Email = model.Email;
                addmems.Address = model.Address;
                await _DemoDbContext.AddAsync(addmems);
                await _DemoDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> deleteMem(int Id)
        {
            //throw new NotImplementedException();
            try { 
                var mem = await _DemoDbContext.Members.FirstOrDefaultAsync(x => x.Id == Id);
                if (mem != null)
                {
                    _DemoDbContext.Members.Remove(mem);
                    await _DemoDbContext.SaveChangesAsync();
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return true;
        }

        public async Task<List<Member>> getAllMem()
        {
            //throw new NotImplementedException();
            var mem = new List<Member>();
            try {
                mem = await _DemoDbContext.Members.ToListAsync();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return mem;
        }

        public async Task<Member> getMemById(int Id)
        {
            //throw new NotImplementedException();
            var mem = new Member();
            try { 
                mem = await _DemoDbContext.Members.FirstOrDefaultAsync(x =>x.Id == Id);
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return mem;
        }

        public async Task<List<ListMember>> getMemByIdJoin(int Id)
        {
            //throw new NotImplementedException();
            try
            {
                var data = await(from a in _DemoDbContext.Members
                                 join b in _DemoDbContext.MemberTypes on a.MemberTypeCode equals b.MemberTypeCode
                                 where a.Id == Id 
                                 select new ListMember
                                 {
                                     Id = a.Id,
                                     MemberName = a.MemberName,
                                     MemberTypeCode = b.MemberTypeCode,
                                     MemberTypeName = b.MemberTypeName,
                                     Mobile = a.Mobile,
                                     Email = a.Email,
                                     Address = a.Address,
                                     Active = b.Active
                                 }).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<ListMember>();
            }
        }     
        
        public async Task<List<ListMember>> getJoinAll()
        {
            try
            {
                var data = await(from a in _DemoDbContext.Members
                                 join b in _DemoDbContext.MemberTypes on a.MemberTypeCode equals b.MemberTypeCode 
                                 select new ListMember
                                 {
                                     Id = a.Id,
                                     MemberName = a.MemberName,
                                     MemberTypeName = b.MemberTypeName,
                                     MemberTypeCode = a.MemberTypeCode,
                                     Mobile = a.Mobile,
                                     Email = a.Email,
                                     Address = a.Address,
                                     Active = b.Active
                                 }).ToListAsync();
                return data;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<ListMember>();
            }
        }

        public async Task<bool> updateMem(MemberViewModel model)
        {
            //throw new NotImplementedException();
            var mem = new Member();
            try { 
                mem = await _DemoDbContext.Members.FirstOrDefaultAsync(x=>x.Id == model.Id);
                if (mem == null)
                {
                    return false;
                }
                mem.Id = model.Id;
                mem.MemberTypeCode = model.MemberTypeCode;
                mem.MemberName = model.MemberName;
                mem.Mobile = model.Mobile;
                mem.Email = model.Email;
                mem.Address = model.Address;
                await _DemoDbContext.SaveChangesAsync();

            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return true;
        }

        //Left Join And Right Join change 
        public async Task<List<ListMember>> getRLjoin()
        {
            try
            {
                var data = await(from a in _DemoDbContext.Members
                                 join b in _DemoDbContext.MemberTypes on a.MemberTypeCode equals b.MemberTypeCode into l_ab
                                 from Members in l_ab.DefaultIfEmpty() //if you need table? chage into and new name Left Join And Right Join change {into g_ab from Members in g_ab.DefaultIfEmpty()}
                                 select new ListMember
                                 {
                                     Id = a.Id,
                                     MemberName = a.MemberName,
                                     MemberTypeName = Members.MemberTypeName,
                                     MemberTypeCode = a.MemberTypeCode,
                                     Mobile = a.Mobile,
                                     Email = a.Email,
                                     Address = a.Address,
                                     Active = Members.Active
                                 }).ToListAsync();
                return data;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<ListMember>();
            }
        }

        public async Task<List<Member>> addBulk(string MemberTypeCode)
        {
            List<Member> member = new List<Member>();
            try
            {
                for (int i = 0; i < 1000; i++)
                {
                    member.Add(new Member()
                    {
                        MemberName = "Pem" + i,
                        MemberTypeCode = MemberTypeCode,
                        Mobile = "000" + i,
                        Email = "pattrawut" + i + "@gmail.com",
                        Address = "0" + i
                    });
                }
                await _DemoDbContext.BulkInsertAsync(member);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return member;
        }

        public async Task<List<Member>> updateBulk(string MemberTypeCode)
        {
            List<Member> Listmember = new List<Member>();
            try
            {
                Listmember = await _DemoDbContext.Members.ToListAsync();
                for (int i = 0; i < Listmember.Count; i++)
                {
                    var n = Listmember[i];
                    n.MemberName = "News_Pem" + i + 10;
                    n.MemberTypeCode = MemberTypeCode;
                    n.Mobile = "000" + i;
                    n.Email = "News_pattrawut" + i + "@gmail.com";
                    n.Address = "News_0" + i;
                }
                await _DemoDbContext.BulkUpdateAsync(Listmember);
                await _DemoDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Listmember;
        }

        public async Task<List<Member>> deleteBulk(string MemberTypeCode)
        {
            List<Member> listMember = new List<Member>();
            try
            { 
                listMember = await _DemoDbContext.Members.Where(x => x.MemberTypeCode == MemberTypeCode).ToListAsync();
                await _DemoDbContext.BulkDeleteAsync(listMember);
                await _DemoDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return listMember;
        }
    }
}
