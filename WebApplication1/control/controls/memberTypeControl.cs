using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.control.Icontrol;
using WebApplication1.control.veiwModel;
using WebApplication1.Models;

namespace WebApplication1.control.controls
{
    public class memberTypeControl : ImemberTypeControl
    {
        private readonly DemoDbContext _demoDbContext; //อ่านข้อมูล model 
        public memberTypeControl(DemoDbContext demoDbContext)
        {
            _demoDbContext = demoDbContext;
        }

        public async Task<bool> add(MemberTypeViewModel model)
        {
            try
            {
                //throw new NotImplementedException();
                MemberType memberTypes = new MemberType();
                memberTypes.MemberTypeCode = model.MemberTypeCode;
                memberTypes.MemberTypeName = model.MemberTypeName;
                memberTypes.Active = model.Active;
                await _demoDbContext.MemberTypes.AddAsync(memberTypes);
                await _demoDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return true;
        }

        public Task<bool> delete(string memberTypeCode)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> deleteData(string memberTypeCode)
        {
            try {
                var memDa = await _demoDbContext.MemberTypes.FirstOrDefaultAsync(x => x.MemberTypeCode == memberTypeCode);
                if (memDa != null)
                {
                    _demoDbContext.MemberTypes.Remove(memDa!);
                    await _demoDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return true;
        }

        public async Task<List<MemberType>> getAll()
        {
            var mem = new List<MemberType>();
            //throw new NotImplementedException();
            try
            {
                mem =  await _demoDbContext.MemberTypes.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return mem;
            
        }

        public async Task<MemberType> getById(string memberTypeCode)
        {
            //throw new NotImplementedException();
            var mem = new MemberType();
            try { 
                mem = await _demoDbContext.MemberTypes.FirstOrDefaultAsync(x=>x.MemberTypeCode== memberTypeCode);
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return mem;
        }

        public async Task<bool> updateData(MemberTypeViewModel model)
        {
            //throw new NotImplementedException();
            var MemberTypes = new MemberType();
            try
            {
                MemberTypes = await _demoDbContext.MemberTypes.FirstOrDefaultAsync(x => x.MemberTypeCode == model.MemberTypeCode);
                if (MemberTypes == null)
                {
                    return false;
                }
                MemberTypes.MemberTypeCode = model.MemberTypeCode;
                MemberTypes.MemberTypeName = model.MemberTypeName;
                MemberTypes.Active = model.Active;
                await _demoDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return true;
        }

        public Task<bool> update(MemberTypeViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
