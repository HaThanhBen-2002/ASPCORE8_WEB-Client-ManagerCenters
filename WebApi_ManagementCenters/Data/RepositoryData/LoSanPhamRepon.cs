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
    public class LoSanPhamRepon: ILoSanPham
    {
        private readonly ApplicationDbContext _context;
        public LoSanPhamRepon(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckId(int id)
        {
            return await _context.LoSanPhams.AnyAsync(c => c.NgayXoa == null && c.NguoiXoa == null && c.MaLoSanPham == id);
        }

        public async Task<bool> Create(LoSanPham item)
        {
            if (item != null)
            {
                item.MaLoSanPham = null;
                await _context.LoSanPhams.AddAsync(item);
            }
            return await Save();
        }

        public Task<bool> Delete(int id, string nguoiXoa, string ngayXoa)
        {
            var itemDelete = _context.LoSanPhams.Where(c => c.NgayXoa == null && c.NguoiXoa == null && c.MaLoSanPham == id).FirstOrDefault();
            if (itemDelete != null)
            {
                itemDelete.NguoiXoa = nguoiXoa;
                itemDelete.NgayXoa = ngayXoa;
                _context.LoSanPhams.Update(itemDelete);
            }
            return Save();
        }

        public async Task<ICollection<LoSanPham>> GetAll()
        {
            var allItem = await _context.LoSanPhams.Where(c => c.NgayXoa == null && c.NguoiXoa == null).ToListAsync();
            return allItem;
        }

        public async Task<LoSanPham> GetById(int id)
        {
            var item = await _context.LoSanPhams.Where(c => c.NgayXoa == null && c.NguoiXoa == null && c.MaLoSanPham == id).FirstOrDefaultAsync();
            if (item != null)
            {
                return item;
            }
            return new LoSanPham();
        }

        private Expression<Func<LoSanPham, bool>> LambdaSearch(LoSanPham item)
        {
            #region Create Lambda
            var parameterExpression = Expression.Parameter(typeof(LoSanPham), "x");
            var expressions = new List<Expression>();
            // Thêm điều kiện tìm kiếm GẦN ĐÚNG STRING
            if (!string.IsNullOrEmpty(item.TenLoSanPham))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(LoSanPham.TenLoSanPham)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.TenLoSanPham)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.TrangThai))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(LoSanPham.TrangThai)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.TrangThai)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.SoLuong))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(LoSanPham.SoLuong)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.SoLuong)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.DonVi))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(LoSanPham.DonVi)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.DonVi)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.NgayNhap))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(LoSanPham.NgayNhap)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.NgayNhap)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.NgayHetHan))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(LoSanPham.NgayHetHan)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.NgayHetHan)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.GhiChu))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(LoSanPham.GhiChu)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.GhiChu)
                );
                expressions.Add(expression);
            }
            // Thêm điều kiện tìm kiếm INT
            if (item.MaLoSanPham.HasValue)
            {
                var expression = Expression.Equal(
                    Expression.Property(parameterExpression, nameof(LoSanPham.MaLoSanPham)),
                    Expression.Constant(item.MaLoSanPham, typeof(int?))
                );
                expressions.Add(expression);
            }
            if (item.MaNhanVien.HasValue)
            {
                var expression = Expression.Equal(
                    Expression.Property(parameterExpression, nameof(LoSanPham.MaNhanVien)),
                    Expression.Constant(item.MaNhanVien, typeof(int?))
                );
                expressions.Add(expression);
            }
            if (item.MaTrungTam.HasValue)
            {
                var expression = Expression.Equal(
                    Expression.Property(parameterExpression, nameof(LoSanPham.MaTrungTam)),
                    Expression.Constant(item.MaTrungTam, typeof(int?))
                );
                expressions.Add(expression);
            }
            if (item.MaSanPham.HasValue)
            {
                var expression = Expression.Equal(
                    Expression.Property(parameterExpression, nameof(LoSanPham.MaSanPham)),
                    Expression.Constant(item.MaSanPham, typeof(int?))
                );
                expressions.Add(expression);
            }
            // Thêm điều kiện Check Ngày Xóa, Người Xóa
            var expressionNgayXoaIsNull = Expression.Equal(Expression.Property(parameterExpression, nameof(LoSanPham.NgayXoa)), Expression.Constant(null, typeof(string)));
            expressions.Add(expressionNgayXoaIsNull);

            var expressionNguoiXoaIsNull = Expression.Equal(Expression.Property(parameterExpression, nameof(LoSanPham.NguoiXoa)), Expression.Constant(null, typeof(string)));
            expressions.Add(expressionNguoiXoaIsNull);

            var combinedExpression = expressions.Any() ? expressions.Aggregate(Expression.AndAlso) : Expression.Constant(true);
            var lambda = Expression.Lambda<Func<LoSanPham, bool>>(combinedExpression, parameterExpression);
            #endregion
            return lambda;
        }

        public object LoadingDataTableView(LoSanPham item, int skip, int take)
        {

            var lambda = LambdaSearch(item);
            // Sử dụng biểu thức lambda để lọc dữ liệu từ DbContext và ánh xạ kết quả vào AcademicScore
            var data = _context.LoSanPhams.Where(lambda).OrderByDescending(n => n.MaLoSanPham).Skip(skip).Take(take).Select( x => new
            {
                x.MaLoSanPham,
                x.TenLoSanPham,
                TenSanPham = x.MaSanPham != null ? _context.SanPhams.Where(sp => sp.MaSanPham == x.MaSanPham).Select(sp => sp.TenSanPham).FirstOrDefault() : null,
                x.TrangThai,
                x.NgayNhap
            }).ToList();
            int recordsTotal = _context.LoSanPhams.Where(lambda).Count();
            var jsonData = new { recordsFiltered = recordsTotal, recordsTotal, data };
            return jsonData;
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<ICollection<LoSanPham>> Search(LoSanPham item)
        {
            var lambda = LambdaSearch(item);

            var filteredResults = await _context.LoSanPhams.Where(lambda).ToListAsync();
            return filteredResults;
        }

        public async Task<int> SearchCount(LoSanPham item)
        {
            var lambda = LambdaSearch(item);
            return _context.LoSanPhams.Where(lambda).Count();
        }

        public async Task<List<object>> SearchName(LoSanPham item)
        {
            var lambda = LambdaSearch(item);

            // Sử dụng biểu thức lambda để lọc dữ liệu từ DbContext và ánh xạ kết quả vào AcademicScore
            var data = await _context.LoSanPhams.Where(lambda).OrderByDescending(n => n.MaLoSanPham).Select(x => new {
                MaLoSanPham = x.MaLoSanPham,
                TenLoSanPham = x.TenLoSanPham
            }).ToListAsync();

            return data.Select(x => new {
                taLoSanPham = x.MaLoSanPham,
                tenLoSanPham = x.TenLoSanPham
            }).ToList<object>();
        }

        public Task<bool> Update(LoSanPham item)
        {
            if (item != null)
            {
                _context.LoSanPhams.Update(item);
            }
            return Save();
        }
    }
}
