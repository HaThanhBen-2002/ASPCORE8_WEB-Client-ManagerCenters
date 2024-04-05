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
    public class KetQuaRepon: IKetQua
    {
        private readonly ApplicationDbContext _context;
        public KetQuaRepon(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckId(int id)
        {
            return await _context.KetQuas.AnyAsync(c => c.NgayXoa == null && c.NguoiXoa == null && c.MaKetQua == id);
        }

        public async Task<bool> Create(KetQua item)
        {
            if (item != null)
            {
                item.MaKetQua = null;
                await _context.KetQuas.AddAsync(item);
            }
            return await Save();
        }

        public Task<bool> Delete(int id, string nguoiXoa, string ngayXoa)
        {
            var itemDelete = _context.KetQuas.Where(c => c.NgayXoa == null && c.NguoiXoa == null && c.MaKetQua == id).FirstOrDefault();
            if (itemDelete != null)
            {
                itemDelete.NguoiXoa = nguoiXoa;
                itemDelete.NgayXoa = ngayXoa;
                _context.KetQuas.Update(itemDelete);
            }
            return Save();
        }

        public async Task<ICollection<KetQua>> GetAll()
        {
            var allItem = await _context.KetQuas.Where(c => c.NgayXoa == null && c.NguoiXoa == null).ToListAsync();
            return allItem;
        }

        public async Task<KetQua> GetById(int id)
        {
            var item = await _context.KetQuas.Where(c => c.NgayXoa == null && c.NguoiXoa == null && c.MaKetQua == id).FirstOrDefaultAsync();
            if (item != null)
            {
                return item;
            }
            return new KetQua();
        }
        private Expression<Func<KetQua, bool>> LambdaSearch(KetQua item)
        {
            #region Create Lambda
            var parameterExpression = Expression.Parameter(typeof(KetQua), "x");
            var expressions = new List<Expression>();
            // Thêm điều kiện tìm kiếm GẦN ĐÚNG STRING
            if (!string.IsNullOrEmpty(item.TenKetQua))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(KetQua.TenKetQua)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.TenKetQua)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.Diem))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(KetQua.Diem)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.Diem)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.XepLoai))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(KetQua.XepLoai)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.XepLoai)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.NgayKiemTra))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(KetQua.NgayKiemTra)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.NgayKiemTra)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.TrangThai))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(KetQua.TrangThai)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.TrangThai)
                );
                expressions.Add(expression);
            }
            // Thêm điều kiện tìm kiếm INT
            if (item.MaKetQua.HasValue)
            {
                var expression = Expression.Equal(
                    Expression.Property(parameterExpression, nameof(KetQua.MaKetQua)),
                    Expression.Constant(item.MaKetQua, typeof(int?))
                );
                expressions.Add(expression);
            }
            if (item.MaHocSinh.HasValue)
            {
                var expression = Expression.Equal(
                    Expression.Property(parameterExpression, nameof(KetQua.MaHocSinh)),
                    Expression.Constant(item.MaHocSinh, typeof(int?))
                );
                expressions.Add(expression);
            }
            if (item.MaTrungTam.HasValue)
            {
                var expression = Expression.Equal(
                    Expression.Property(parameterExpression, nameof(KetQua.MaTrungTam)),
                    Expression.Constant(item.MaTrungTam, typeof(int?))
                );
                expressions.Add(expression);
            }
            if (item.MaMonHoc.HasValue)
            {
                var expression = Expression.Equal(
                    Expression.Property(parameterExpression, nameof(KetQua.MaMonHoc)),
                    Expression.Constant(item.MaMonHoc, typeof(int?))
                );
                expressions.Add(expression);
            }
            if (item.MaNhanVien.HasValue)
            {
                var expression = Expression.Equal(
                    Expression.Property(parameterExpression, nameof(KetQua.MaNhanVien)),
                    Expression.Constant(item.MaNhanVien, typeof(int?))
                );
                expressions.Add(expression);
            }
            // Thêm điều kiện Check Ngày Xóa, Người Xóa
            var expressionNgayXoaIsNull = Expression.Equal(Expression.Property(parameterExpression, nameof(KetQua.NgayXoa)), Expression.Constant(null, typeof(string)));
            expressions.Add(expressionNgayXoaIsNull);

            var expressionNguoiXoaIsNull = Expression.Equal(Expression.Property(parameterExpression, nameof(KetQua.NguoiXoa)), Expression.Constant(null, typeof(string)));
            expressions.Add(expressionNguoiXoaIsNull);

            var combinedExpression = expressions.Any() ? expressions.Aggregate(Expression.AndAlso) : Expression.Constant(true);
            var lambda = Expression.Lambda<Func<KetQua, bool>>(combinedExpression, parameterExpression);
            #endregion
            return lambda;
        }
        public object LoadingDataTableView(KetQua item, int skip, int take)
        {

            var lambda = LambdaSearch(item);
            // Sử dụng biểu thức lambda để lọc dữ liệu từ DbContext và ánh xạ kết quả vào AcademicScore
            var data = _context.KetQuas.Where(lambda).OrderByDescending(n => n.MaKetQua).Skip(skip).Take(take).Select(x => new
            {
                x.MaKetQua,
                x.TenKetQua,
                TenHocSinh = x.MaHocSinh != null ? _context.HocSinhs.Where(mh => mh.MaHocSinh == x.MaHocSinh).Select(mh => mh.TenHocSinh).FirstOrDefault() : null,
                TenMonHoc = x.MaMonHoc != null ? _context.MonHocs.Where(mh => mh.MaMonHoc == x.MaMonHoc).Select(mh => mh.TenMonHoc).FirstOrDefault() : null,
                x.TrangThai
            }).ToList();
            int recordsTotal = _context.KetQuas.Where(lambda).Count();
            var jsonData = new { recordsFiltered = recordsTotal, recordsTotal, data };
            return jsonData;
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<ICollection<KetQua>> Search(KetQua item)
        {
            var lambda = LambdaSearch(item);

            var filteredResults = await _context.KetQuas.Where(lambda).ToListAsync();
            return filteredResults;
        }

        public async Task<int> SearchCount(KetQua item)
        {
            var lambda = LambdaSearch(item);
            return _context.KetQuas.Where(lambda).Count();
        }

        public async Task<List<object>> SearchName(KetQua item)
        {
            var lambda = LambdaSearch(item);

            // Sử dụng biểu thức lambda để lọc dữ liệu từ DbContext và ánh xạ kết quả vào AcademicScore
            var data = await _context.KetQuas.Where(lambda).OrderByDescending(n => n.MaKetQua).Select(x => new {
                MaKetQua = x.MaKetQua,
                TenKetQua = x.TenKetQua
            }).ToListAsync();

            return data.Select(x => new {
                maKetQua = x.MaKetQua,
                tenKetQua = x.TenKetQua
            }).ToList<object>();
        }

        public Task<bool> Update(KetQua item)
        {
            if (item != null)
            {
                _context.KetQuas.Update(item);
            }
            return Save();
        }
    }
}
