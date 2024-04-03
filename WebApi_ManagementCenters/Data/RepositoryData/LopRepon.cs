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
    public class LopRepon: ILop
    {
        private readonly ApplicationDbContext _context;
        public LopRepon(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CheckId(int id)
        {
            return await _context.Lops.AnyAsync(c => c.NgayXoa == null && c.NguoiXoa == null && c.MaLop == id);
        }

        public async Task<bool> Create(Lop item)
        {
            if (item != null)
            {
                item.MaLop = null;
                await _context.Lops.AddAsync(item);
            }
            return await Save();
        }

        public Task<bool> Delete(int id, string nguoiXoa, string ngayXoa)
        {
            var itemDelete = _context.Lops.Where(c => c.NgayXoa == null && c.NguoiXoa == null && c.MaLop == id).FirstOrDefault();
            if (itemDelete != null)
            {
                itemDelete.NguoiXoa = nguoiXoa;
                itemDelete.NgayXoa = ngayXoa;
                _context.Lops.Update(itemDelete);
            }
            return Save();
        }

        public async Task<ICollection<Lop>> GetAll()
        {
            var allItem = await _context.Lops.Where(c => c.NgayXoa == null && c.NguoiXoa == null).ToListAsync();
            return allItem;
        }

        public async Task<Lop> GetById(int id)
        {
            var item = await _context.Lops.Where(c => c.NgayXoa == null && c.NguoiXoa == null && c.MaLop == id).FirstOrDefaultAsync();
            if (item != null)
            {
                return item;
            }
            return new Lop();
        }

        private Expression<Func<Lop, bool>> LambdaSearch(Lop item)
        {
            #region Create Lambda
            var parameterExpression = Expression.Parameter(typeof(Lop), "x");
            var expressions = new List<Expression>();
            // Thêm điều kiện tìm kiếm GẦN ĐÚNG STRING
            if (!string.IsNullOrEmpty(item.TenLop))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(Lop.TenLop)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.TenLop)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.HocPhi))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(Lop.HocPhi)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.HocPhi)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.LichHoc))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(Lop.LichHoc)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.LichHoc)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.ThongTin))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(Lop.ThongTin)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.ThongTin)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.NgayBatDau))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(Lop.NgayBatDau)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.NgayBatDau)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.NgayKetThuc))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(Lop.NgayKetThuc)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.NgayKetThuc)
                );
                expressions.Add(expression);
            }
            // Thêm điều kiện tìm kiếm INT
            if (item.MaLop.HasValue)
            {
                var expression = Expression.Equal(
                    Expression.Property(parameterExpression, nameof(Lop.MaLop)),
                    Expression.Constant(item.MaLop, typeof(int?))
                );
                expressions.Add(expression);
            }
            if (item.MaNhanVien.HasValue)
            {
                var expression = Expression.Equal(
                    Expression.Property(parameterExpression, nameof(Lop.MaNhanVien)),
                    Expression.Constant(item.MaNhanVien, typeof(int?))
                );
                expressions.Add(expression);
            }
            if (item.MaTrungTam.HasValue)
            {
                var expression = Expression.Equal(
                    Expression.Property(parameterExpression, nameof(Lop.MaTrungTam)),
                    Expression.Constant(item.MaTrungTam, typeof(int?))
                );
                expressions.Add(expression);
            }
            if (item.NamHoc.HasValue)
            {
                var expression = Expression.Equal(
                    Expression.Property(parameterExpression, nameof(Lop.NamHoc)),
                    Expression.Constant(item.NamHoc, typeof(int?))
                );
                expressions.Add(expression);
            }
            // Thêm điều kiện Check Ngày Xóa, Người Xóa
            var expressionNgayXoaIsNull = Expression.Equal(Expression.Property(parameterExpression, nameof(Lop.NgayXoa)), Expression.Constant(null, typeof(string)));
            expressions.Add(expressionNgayXoaIsNull);

            var expressionNguoiXoaIsNull = Expression.Equal(Expression.Property(parameterExpression, nameof(Lop.NguoiXoa)), Expression.Constant(null, typeof(string)));
            expressions.Add(expressionNguoiXoaIsNull);

            var combinedExpression = expressions.Any() ? expressions.Aggregate(Expression.AndAlso) : Expression.Constant(true);
            var lambda = Expression.Lambda<Func<Lop, bool>>(combinedExpression, parameterExpression);
            #endregion
            return lambda;
        }

        public object LoadingDataTableView(Lop item, int skip, int take)
        {

            var lambda = LambdaSearch(item);
            // Sử dụng biểu thức lambda để lọc dữ liệu từ DbContext và ánh xạ kết quả vào AcademicScore
            var data = _context.Lops.Where(lambda).OrderByDescending(n => n.MaLop).Skip(skip).Take(take).Select(x => new
            {
                x.MaLop,
                x.TenLop,
                TenGiaoVien = x.MaNhanVien != null ? _context.NhanViens.Where(nv => nv.MaNhanVien == x.MaNhanVien).Select(nv => nv.TenNhanVien).FirstOrDefault() : null,
                x.HocPhi,
                x.NamHoc
            }).ToList();
            int recordsTotal = _context.Lops.Where(lambda).Count();
            var jsonData = new { recordsFiltered = recordsTotal, recordsTotal, data };
            return jsonData;
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<ICollection<Lop>> Search(Lop item)
        {
            var lambda = LambdaSearch(item);

            var filteredResults = await _context.Lops.Where(lambda).ToListAsync();
            return filteredResults;
        }

        public async Task<int> SearchCount(Lop item)
        {
            var lambda = LambdaSearch(item);
            return _context.Lops.Where(lambda).Count();
        }

        public async Task<List<object>> SearchName(Lop item)
        {
            var lambda = LambdaSearch(item);

            // Sử dụng biểu thức lambda để lọc dữ liệu từ DbContext và ánh xạ kết quả vào AcademicScore
            var data = await _context.Lops.Where(lambda).OrderByDescending(n => n.MaLop).Select(x => new {
                MaLop = x.MaLop,
                TenLop = x.TenLop
            }).ToListAsync();

            return data.Select(x => new {
                maLop = x.MaLop,
                tenLop = x.TenLop
            }).ToList<object>();
        }

        public Task<bool> Update(Lop item)
        {
            if (item != null)
            {
                _context.Lops.Update(item);
            }
            return Save();
        }
    }
}
