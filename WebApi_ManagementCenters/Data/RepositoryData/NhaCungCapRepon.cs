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
    public class NhaCungCapRepon: INhaCungCap
    {
        private readonly ApplicationDbContext _context;
        public NhaCungCapRepon(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CheckId(int id)
        {
            return await _context.NhaCungCaps.AnyAsync(c => c.NgayXoa == null && c.NguoiXoa == null && c.MaNhaCungCap == id);
        }

        public async Task<bool> Create(NhaCungCap item)
        {
            if (item != null)
            {
                item.MaNhaCungCap = null;
                await _context.NhaCungCaps.AddAsync(item);
            }
            return await Save();
        }

        public Task<bool> Delete(int id, string nguoiXoa, string ngayXoa)
        {
            var itemDelete = _context.NhaCungCaps.Where(c => c.NgayXoa == null && c.NguoiXoa == null && c.MaNhaCungCap == id).FirstOrDefault();
            if (itemDelete != null)
            {
                itemDelete.NguoiXoa = nguoiXoa;
                itemDelete.NgayXoa = ngayXoa;
                _context.NhaCungCaps.Update(itemDelete);
            }
            return Save();
        }

        public async Task<ICollection<NhaCungCap>> GetAll()
        {
            var allItem = await _context.NhaCungCaps.Where(c => c.NgayXoa == null && c.NguoiXoa == null).ToListAsync();
            return allItem;
        }

        public async Task<NhaCungCap> GetById(int id)
        {
            var item = await _context.NhaCungCaps.Where(c => c.NgayXoa == null && c.NguoiXoa == null && c.MaNhaCungCap == id).FirstOrDefaultAsync();
            if (item != null)
            {
                return item;
            }
            return new NhaCungCap();
        }

        private Expression<Func<NhaCungCap, bool>> LambdaSearch(NhaCungCap item)
        {
            #region Create Lambda
            var parameterExpression = Expression.Parameter(typeof(NhaCungCap), "x");
            var expressions = new List<Expression>();
            // Thêm điều kiện tìm kiếm GẦN ĐÚNG STRING
            if (!string.IsNullOrEmpty(item.TenNhaCungCap))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(NhaCungCap.TenNhaCungCap)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.TenNhaCungCap)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.GioiThieu))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(NhaCungCap.GioiThieu)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.GioiThieu)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.Email))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(NhaCungCap.Email)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.Email)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.SoDienThoai))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(NhaCungCap.SoDienThoai)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.SoDienThoai)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.NganHang))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(NhaCungCap.NganHang)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.NganHang)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.SoTaiKhoan))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(NhaCungCap.SoTaiKhoan)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.SoTaiKhoan)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.MaSoThue))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(NhaCungCap.MaSoThue)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.MaSoThue)
                );
                expressions.Add(expression);
            }
            // Thêm điều kiện tìm kiếm INT
            if (item.MaNhaCungCap.HasValue)
            {
                var expression = Expression.Equal(
                    Expression.Property(parameterExpression, nameof(NhaCungCap.MaNhaCungCap)),
                    Expression.Constant(item.MaNhaCungCap, typeof(int?))
                );
                expressions.Add(expression);
            }
            if (item.MaTrungTam.HasValue)
            {
                var expression = Expression.Equal(
                    Expression.Property(parameterExpression, nameof(NhaCungCap.MaTrungTam)),
                    Expression.Constant(item.MaTrungTam, typeof(int?))
                );
                expressions.Add(expression);
            }
            // Thêm điều kiện Check Ngày Xóa, Người Xóa
            var expressionNgayXoaIsNull = Expression.Equal(Expression.Property(parameterExpression, nameof(NhaCungCap.NgayXoa)), Expression.Constant(null, typeof(string)));
            expressions.Add(expressionNgayXoaIsNull);

            var expressionNguoiXoaIsNull = Expression.Equal(Expression.Property(parameterExpression, nameof(NhaCungCap.NguoiXoa)), Expression.Constant(null, typeof(string)));
            expressions.Add(expressionNguoiXoaIsNull);

            var combinedExpression = expressions.Any() ? expressions.Aggregate(Expression.AndAlso) : Expression.Constant(true);
            var lambda = Expression.Lambda<Func<NhaCungCap, bool>>(combinedExpression, parameterExpression);
            #endregion
            return lambda;
        }


        public object LoadingDataTableView(NhaCungCap item, int skip, int take)
        {
            var lambda = LambdaSearch(item);

            // Sử dụng biểu thức lambda để lọc dữ liệu từ DbContext và ánh xạ kết quả vào AcademicScore
            var data = _context.NhaCungCaps.Where(lambda).OrderByDescending(n => n.MaNhaCungCap).Skip(skip).Take(take).Select(x => new
            {
                x.MaNhaCungCap,
                x.TenNhaCungCap,
                x.Email,
                x.SoDienThoai,
                x.MaSoThue
            }).ToList();
            int recordsTotal = _context.NhaCungCaps.Where(lambda).Count();
            var jsonData = new { recordsFiltered = recordsTotal, recordsTotal, data };
            return jsonData;
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<ICollection<NhaCungCap>> Search(NhaCungCap item)
        {
            var lambda = LambdaSearch(item);

            var filteredResults = await _context.NhaCungCaps.Where(lambda).ToListAsync();
            return filteredResults;
        }

        public async Task<int> SearchCount(NhaCungCap item)
        {
            var lambda = LambdaSearch(item);
            return _context.NhaCungCaps.Where(lambda).Count();
        }

        public async Task<List<object>> SearchName(NhaCungCap item)
        {
            var lambda = LambdaSearch(item);

            // Sử dụng biểu thức lambda để lọc dữ liệu từ DbContext và ánh xạ kết quả vào AcademicScore
            var data = await _context.NhaCungCaps.Where(lambda).OrderByDescending(n => n.MaNhaCungCap).Select(x => new {
                MaNhaCungCap = x.MaNhaCungCap,
                TenNhaCungCap = x.TenNhaCungCap,
                Email = x.Email
            }).ToListAsync();

            return data.Select(x => new {
                maNhaCungCap = x.MaNhaCungCap,
                tenNhaCungCap = x.TenNhaCungCap,
                email = x.Email
            }).ToList<object>();
        }

        public Task<bool> Update(NhaCungCap item)
        {
            if (item != null)
            {
                _context.NhaCungCaps.Update(item);
            }
            return Save();
        }
    }
}
