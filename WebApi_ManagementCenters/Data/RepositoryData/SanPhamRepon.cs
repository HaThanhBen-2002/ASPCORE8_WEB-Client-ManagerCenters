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
    public class SanPhamRepon: ISanPham
    {
        private readonly ApplicationDbContext _context;
        public SanPhamRepon(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CheckId(int id)
        {
            return await _context.SanPhams.AnyAsync(c => c.NgayXoa == null && c.NguoiXoa == null && c.MaSanPham == id);
        }

        public async Task<bool> Create(SanPham item)
        {
            if (item != null)
            {
                item.MaSanPham = null;
                await _context.SanPhams.AddAsync(item);
            }
            return await Save();
        }

        public Task<bool> Delete(int id, string nguoiXoa, string ngayXoa)
        {
            var itemDelete = _context.SanPhams.Where(c => c.NgayXoa == null && c.NguoiXoa == null && c.MaSanPham == id).FirstOrDefault();
            if (itemDelete != null)
            {
                itemDelete.NguoiXoa = nguoiXoa;
                itemDelete.NgayXoa = ngayXoa;
                _context.SanPhams.Update(itemDelete);
            }
            return Save();
        }

        public async Task<ICollection<SanPham>> GetAll()
        {
            var allItem = await _context.SanPhams.Where(c => c.NgayXoa == null && c.NguoiXoa == null).ToListAsync();
            return allItem;
        }

        public async Task<SanPham> GetById(int id)
        {
            var item = await _context.SanPhams.Where(c => c.NgayXoa == null && c.NguoiXoa == null && c.MaSanPham == id).FirstOrDefaultAsync();
            if (item != null)
            {
                return item;
            }
            return new SanPham();
        }
        private Expression<Func<SanPham, bool>> LambdaSearch(SanPham item)
        {
            #region Create Lambda
            var parameterExpression = Expression.Parameter(typeof(SanPham), "x");
            var expressions = new List<Expression>();
            // Thêm điều kiện tìm kiếm GẦN ĐÚNG STRING
            if (!string.IsNullOrEmpty(item.TenSanPham))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(SanPham.TenSanPham)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.TenSanPham)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.ThongTin))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(SanPham.ThongTin)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.ThongTin)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.LoaiSanPham))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(SanPham.LoaiSanPham)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.LoaiSanPham)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.ThongTin))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(SanPham.ThongTin)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.ThongTin)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.HanSuDung))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(SanPham.HanSuDung)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.HanSuDung)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.Gia))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(SanPham.Gia)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.Gia)
                );
                expressions.Add(expression);
            }
            // Thêm điều kiện tìm kiếm INT
            if (item.MaSanPham.HasValue)
            {
                var expression = Expression.Equal(
                    Expression.Property(parameterExpression, nameof(SanPham.MaSanPham)),
                    Expression.Constant(item.MaSanPham, typeof(int?))
                );
                expressions.Add(expression);
            }
            if (item.MaNhaCungCap.HasValue)
            {
                var expression = Expression.Equal(
                    Expression.Property(parameterExpression, nameof(SanPham.MaNhaCungCap)),
                    Expression.Constant(item.MaNhaCungCap, typeof(int?))
                );
                expressions.Add(expression);
            }
            if (item.MaTrungTam.HasValue)
            {
                var expression = Expression.Equal(
                    Expression.Property(parameterExpression, nameof(SanPham.MaTrungTam)),
                    Expression.Constant(item.MaTrungTam, typeof(int?))
                );
                expressions.Add(expression);
            }
            // Thêm điều kiện Check Ngày Xóa, Người Xóa
            var expressionNgayXoaIsNull = Expression.Equal(Expression.Property(parameterExpression, nameof(SanPham.NgayXoa)), Expression.Constant(null, typeof(string)));
            expressions.Add(expressionNgayXoaIsNull);

            var expressionNguoiXoaIsNull = Expression.Equal(Expression.Property(parameterExpression, nameof(SanPham.NguoiXoa)), Expression.Constant(null, typeof(string)));
            expressions.Add(expressionNguoiXoaIsNull);

            var combinedExpression = expressions.Any() ? expressions.Aggregate(Expression.AndAlso) : Expression.Constant(true);
            var lambda = Expression.Lambda<Func<SanPham, bool>>(combinedExpression, parameterExpression);
            #endregion
            return lambda;
        }
        public object LoadingDataTableView(SanPham item, int skip, int take)
        {
            var lambda = LambdaSearch(item);

            // Sử dụng biểu thức lambda để lọc dữ liệu từ DbContext và ánh xạ kết quả vào AcademicScore
            var data = _context.SanPhams.Where(lambda).OrderByDescending(n => n.MaSanPham).Skip(skip).Take(take).Select(x => new
                {
                    x.MaSanPham,
                    x.TenSanPham,
                    x.LoaiSanPham,
                    x.HanSuDung,
                    x.Gia,
                    TenNhaCungCap = x.MaNhaCungCap != null ? _context.NhaCungCaps.Where(nc => nc.MaNhaCungCap == x.MaNhaCungCap).Select(nc => nc.TenNhaCungCap).FirstOrDefault() : null,
                }).ToList();
            int recordsTotal = _context.SanPhams.Where(lambda).Count();
            var jsonData = new { recordsFiltered = recordsTotal, recordsTotal, data };
            return jsonData;
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<ICollection<SanPham>> Search(SanPham item)
        {
            var lambda = LambdaSearch(item);

            var filteredResults = await _context.SanPhams.Where(lambda).ToListAsync();
            return filteredResults;
        }

        public async Task<int> SearchCount(SanPham item)
        {
            var lambda = LambdaSearch(item);
            return _context.SanPhams.Where(lambda).Count();
        }

        public async Task<List<object>> SearchName(SanPham item)
        {
            var lambda = LambdaSearch(item);

            // Sử dụng biểu thức lambda để lọc dữ liệu từ DbContext và ánh xạ kết quả vào AcademicScore
            var data = await _context.SanPhams.Where(lambda).OrderByDescending(n => n.MaSanPham).Select(x => new {
                MaSanPham = x.MaSanPham,
                TenSanPham = x.TenSanPham
            }).ToListAsync();

            return data.Select(x => new {
                maSanPham = x.MaSanPham,
                tenSanPham = x.TenSanPham
            }).ToList<object>();
        }

        public Task<bool> Update(SanPham item)
        {
            if (item != null)
            {
                _context.SanPhams.Update(item);
            }
            return Save();
        }
    }
}
