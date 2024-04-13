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
    public class NhanVienRepon: INhanVien
    {
        private readonly ApplicationDbContext _context;
        public NhanVienRepon(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CheckId(int id)
        {
            return await _context.NhanViens.AnyAsync(c => c.NgayXoa == null && c.NguoiXoa == null && c.MaNhanVien == id);
        }

        public async Task<bool> Create(NhanVien item)
        {
            if (item != null)
            {
                item.MaNhanVien = null;
                await _context.NhanViens.AddAsync(item);
            }
            return await Save();
        }

        public Task<bool> Delete(int id, string nguoiXoa, string ngayXoa)
        {
            var itemDelete = _context.NhanViens.Where(c => c.NgayXoa == null && c.NguoiXoa == null && c.MaNhanVien == id).FirstOrDefault();
            if (itemDelete != null)
            {
                itemDelete.NguoiXoa = nguoiXoa;
                itemDelete.NgayXoa = ngayXoa;
                _context.NhanViens.Update(itemDelete);
            }
            return Save();
        }

        public async Task<ICollection<NhanVien>> GetAll()
        {
            var allItem = await _context.NhanViens.Where(c => c.NgayXoa == null && c.NguoiXoa == null).ToListAsync();
            return allItem;
        }

        public async Task<NhanVien> GetById(int id)
        {
            var item = await _context.NhanViens.Where(c => c.NgayXoa == null && c.NguoiXoa == null && c.MaNhanVien == id).FirstOrDefaultAsync();
            if (item != null)
            {
                return item;
            }
            return new NhanVien();
        }

        private Expression<Func<NhanVien, bool>> LambdaSearch(NhanVien item)
        {
            #region Create Lambda
            var parameterExpression = Expression.Parameter(typeof(NhanVien), "x");
            var expressions = new List<Expression>();
            // Thêm điều kiện tìm kiếm GẦN ĐÚNG STRING
            if (!string.IsNullOrEmpty(item.TenNhanVien))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(NhanVien.TenNhanVien)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.TenNhanVien)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.Cccd))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(NhanVien.Cccd)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.Cccd)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.NgaySinh))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(NhanVien.NgaySinh)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.NgaySinh)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.GioiTinh))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(NhanVien.GioiTinh)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.GioiTinh)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.DiaChi))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(NhanVien.DiaChi)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.DiaChi)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.SoDienThoai))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(NhanVien.SoDienThoai)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.SoDienThoai)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.Email))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(NhanVien.Email)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.Email)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.ThongTin))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(NhanVien.ThongTin)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.ThongTin)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.LoaiNhanVien))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(NhanVien.LoaiNhanVien)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.LoaiNhanVien)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.MaTaiKhoan))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(NhanVien.MaTaiKhoan)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.MaTaiKhoan)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.PhongBan))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(NhanVien.PhongBan)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.PhongBan)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.Luong))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(NhanVien.Luong)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.Luong)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.NganHang))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(NhanVien.NganHang)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.NganHang)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.SoTaiKhoan))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(NhanVien.SoTaiKhoan)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.SoTaiKhoan)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.DanToc))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(NhanVien.DanToc)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.DanToc)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.TonGiao))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(NhanVien.TonGiao)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.TonGiao)
                );
                expressions.Add(expression);
            }
            // Thêm điều kiện tìm kiếm INT
            if (item.MaNhanVien.HasValue)
            {
                var expression = Expression.Equal(
                    Expression.Property(parameterExpression, nameof(NhanVien.MaNhanVien)),
                    Expression.Constant(item.MaNhanVien, typeof(int?))
                );
                expressions.Add(expression);
            }
            if (item.MaTrungTam.HasValue)
            {
                var expression = Expression.Equal(
                    Expression.Property(parameterExpression, nameof(NhanVien.MaTrungTam)),
                    Expression.Constant(item.MaTrungTam, typeof(int?))
                );
                expressions.Add(expression);
            }
            // Thêm điều kiện Check Ngày Xóa, Người Xóa
            var expressionNgayXoaIsNull = Expression.Equal(Expression.Property(parameterExpression, nameof(NhanVien.NgayXoa)), Expression.Constant(null, typeof(string)));
            expressions.Add(expressionNgayXoaIsNull);

            var expressionNguoiXoaIsNull = Expression.Equal(Expression.Property(parameterExpression, nameof(NhanVien.NguoiXoa)), Expression.Constant(null, typeof(string)));
            expressions.Add(expressionNguoiXoaIsNull);

            var combinedExpression = expressions.Any() ? expressions.Aggregate(Expression.AndAlso) : Expression.Constant(true);
            var lambda = Expression.Lambda<Func<NhanVien, bool>>(combinedExpression, parameterExpression);
            #endregion
            return lambda;
        }

        public object LoadingDataTableView(NhanVien item, int skip, int take)
        {
            var lambda = LambdaSearch(item);

            // Sử dụng biểu thức lambda để lọc dữ liệu từ DbContext và ánh xạ kết quả vào AcademicScore
            var data = _context.NhanViens.Where(lambda).OrderByDescending(n => n.MaNhanVien).Skip(skip).Take(take).Select(x => new
            {
                x.MaNhanVien,
                x.TenNhanVien,
                x.NgaySinh,
                x.GioiTinh,
                x.LoaiNhanVien,
                x.PhongBan
            }).ToList();
            int recordsTotal = _context.NhanViens.Where(lambda).Count();
            var jsonData = new { recordsFiltered = recordsTotal, recordsTotal, data };
            return jsonData;
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<ICollection<NhanVien>> Search(NhanVien item)
        {
            var lambda = LambdaSearch(item);

            var filteredResults = await _context.NhanViens.Where(lambda).ToListAsync();
            foreach (var result in filteredResults)
            {
                result.HinhAnh = null;
            }
            return filteredResults;
        }

        public async Task<int> SearchCount(NhanVien item)
        {
            var lambda = LambdaSearch(item);
            return _context.NhanViens.Where(lambda).Count();
        }

        public async Task<List<object>> SearchName(NhanVien item)
        {
            var lambda = LambdaSearch(item);
            // Sử dụng biểu thức lambda để lọc dữ liệu từ DbContext và ánh xạ kết quả vào AcademicScore
            var data = await _context.NhanViens.Where(lambda).OrderByDescending(n => n.MaNhanVien).Select(x => new {
                MaNhanVien = x.MaNhanVien,
                TenNhanVien = x.TenNhanVien,
                Email = x.Email,
            }).ToListAsync();

            return data.Select(x => new {
                maNhanVien = x.MaNhanVien,
                tenNhanVien = x.TenNhanVien,
                email = x.Email
            }).ToList<object>();
        }

        public Task<bool> Update(NhanVien item)
        {
            if (item != null)
            {
                _context.NhanViens.Update(item);
            }
            return Save();
        }
    }
}
