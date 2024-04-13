using Data.Dtos;
using Data.InterfacesData;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace Data.RepositoryData
{
    public class TrungTamRepon: ITrungTam
    {
        private readonly ApplicationDbContext _context;
        public TrungTamRepon(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CheckId(int id)
        {
            return await _context.TrungTams.AnyAsync(c => c.NgayXoa == null && c.NguoiXoa == null && c.MaTrungTam == id);
        }

        public async Task<bool> Create(TrungTam item)
        {
            if (item != null)
            {
                item.MaTrungTam = null;
                await _context.AddAsync(item);
            }
            return await Save();
        }

        public Task<bool> Delete(int id, string nguoiXoa, string ngayXoa)
        {
            var itemDelete = _context.TrungTams.Where(c => c.NgayXoa == null && c.NguoiXoa == null && c.MaTrungTam == id).FirstOrDefault();
            if (itemDelete != null)
            {
                itemDelete.NguoiXoa = nguoiXoa;
                itemDelete.NgayXoa = ngayXoa;
                _context.Update(itemDelete);
            }
            return Save();
        }

        public async Task<ICollection<TrungTam>> GetAll()
        {
            var allItem = await _context.TrungTams.Where(c => c.NgayXoa == null && c.NguoiXoa == null).ToListAsync();
            return allItem;
        }

        public async Task<TrungTam> GetById(int id)
        {
            var item = await _context.TrungTams.Where(c => c.NgayXoa == null && c.NguoiXoa == null && c.MaTrungTam == id).FirstOrDefaultAsync();
            if (item != null)
            {
                return item;
            }
            return new TrungTam();
        }

        private Expression<Func<TrungTam,bool>> LambdaSearch(TrungTam item)
        {
            #region Create Lambda
            var parameterExpression = Expression.Parameter(typeof(TrungTam), "x");
            var expressions = new List<Expression>();


            // Thêm điều kiện tìm kiếm GẦN ĐÚNG STRING
            if (!string.IsNullOrEmpty(item.TenTrungTam))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(TrungTam.TenTrungTam)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.TenTrungTam)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.DiaChi))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(TrungTam.DiaChi)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.DiaChi)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.Email))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(TrungTam.Email)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.Email)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.MaSoThue))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(TrungTam.MaSoThue)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.MaSoThue)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.SoDienThoai))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(TrungTam.SoDienThoai)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.SoDienThoai)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.DienTich))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(TrungTam.DienTich)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.DienTich)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.NganHang))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(TrungTam.NganHang)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.NganHang)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.SoTaiKhoan))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(TrungTam.SoTaiKhoan)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.SoTaiKhoan)
                );
                expressions.Add(expression);
            }
            // Thêm điều kiện tìm kiếm INT
            if (item.MaTrungTam.HasValue)
            {
                var expression = Expression.Equal(
                    Expression.Property(parameterExpression, nameof(TrungTam.MaTrungTam)),
                    Expression.Constant(item.MaTrungTam, typeof(int?))
                );
                expressions.Add(expression);
            }
            // Thêm điều kiện Check Ngày Xóa, Người Xóa
            var expressionNgayXoaIsNull = Expression.Equal(Expression.Property(parameterExpression, nameof(TrungTam.NgayXoa)), Expression.Constant(null, typeof(string)));
            expressions.Add(expressionNgayXoaIsNull);

            var expressionNguoiXoaIsNull = Expression.Equal(Expression.Property(parameterExpression, nameof(TrungTam.NguoiXoa)), Expression.Constant(null, typeof(string)));
            expressions.Add(expressionNguoiXoaIsNull);

            var combinedExpression = expressions.Any() ? expressions.Aggregate(Expression.AndAlso) : Expression.Constant(true);
            var lambda = Expression.Lambda<Func<TrungTam, bool>>(combinedExpression, parameterExpression);
            #endregion
            return lambda;
        }
        public object LoadingDataTableView(TrungTam item, int skip, int take)
        {
            var lambda = LambdaSearch(item);
            // Sử dụng biểu thức lambda để lọc dữ liệu từ DbContext và ánh xạ kết quả vào AcademicScore
            var data = _context.TrungTams.Where(lambda).OrderByDescending(n => n.MaTrungTam).Skip(skip).Take(take).Select(x => new
            {
                 x.MaTrungTam,
                 x.TenTrungTam,
                 x.Email,
                 x.SoDienThoai,
                 x.DienTich,
                 x.DiaChi
            }).ToList();
            int recordsTotal = _context.TrungTams.Where(lambda).Count();
            var jsonData = new { recordsFiltered = recordsTotal, recordsTotal, data };
            return jsonData;
        }

        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ICollection<TrungTam>> Search(TrungTam item)
        {
            var lambda = LambdaSearch(item);

            var filteredResults = await _context.TrungTams.Where(lambda).ToListAsync();
            return filteredResults;
        }

        public async Task<int> SearchCount(TrungTam item)
        {
            var lambda = LambdaSearch(item);
            int numberCount =  _context.TrungTams.Where(lambda).Count();
            return numberCount;
        }

        public async Task<List<object>> SearchName(TrungTam item)
        {
            var lambda = LambdaSearch(item);
            var data = await _context.TrungTams.Where(lambda).OrderByDescending(n => n.MaTrungTam).Select(x => new {
            MaTrungTam = x.MaTrungTam,
            TenTrungTam = x.TenTrungTam,
            Email = x.Email
            }).ToListAsync();

            return data.Select(x => new {
                maTrungTam = x.MaTrungTam,
                tenTrungTam = x.TenTrungTam,
                email = x.Email
            }).ToList<object>();
        }

        public Task<bool> Update(TrungTam item)
        {
            if (item != null)
            {
                _context.Update(item);
            }
            return Save();
        }
    }
}
