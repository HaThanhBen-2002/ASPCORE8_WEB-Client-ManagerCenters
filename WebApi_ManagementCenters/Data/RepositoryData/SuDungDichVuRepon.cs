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
    public class SuDungDichVuRepon: ISuDungDichVu
    {
        private readonly ApplicationDbContext _context;
        public SuDungDichVuRepon(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CheckId(int id)
        {
            return await _context.SuDungDichVus.AnyAsync(c => c.NgayXoa == null && c.NguoiXoa == null && c.MaSuDungDichVu == id);
        }

        public async Task<bool> Create(SuDungDichVu item)
        {
            if (item != null)
            {
                item.MaSuDungDichVu = null;
                await _context.SuDungDichVus.AddAsync(item);
            }
            return await Save();
        }

        public Task<bool> Delete(int id, string nguoiXoa, string ngayXoa)
        {
            var itemDelete = _context.SuDungDichVus.Where(c => c.NgayXoa == null && c.NguoiXoa == null && c.MaSuDungDichVu == id).FirstOrDefault();
            if (itemDelete != null)
            {
                itemDelete.NguoiXoa = nguoiXoa;
                itemDelete.NgayXoa = ngayXoa;
                _context.SuDungDichVus.Update(itemDelete);
            }
            return Save();
        }

        public async Task<ICollection<SuDungDichVu>> GetAll()
        {
            var allItem = await _context.SuDungDichVus.Where(c => c.NgayXoa == null && c.NguoiXoa == null).ToListAsync();
            return allItem;
        }

        public async Task<SuDungDichVu> GetById(int id)
        {
            var item = await _context.SuDungDichVus.Where(c => c.NgayXoa == null && c.NguoiXoa == null && c.MaSuDungDichVu == id).FirstOrDefaultAsync();
            if (item != null)
            {
                return item;
            }
            return new SuDungDichVu();
        }
        private Expression<Func<SuDungDichVu, bool>> LambdaSearch(SuDungDichVu item)
        {
            #region Create Lambda
            var parameterExpression = Expression.Parameter(typeof(SuDungDichVu), "x");
            var expressions = new List<Expression>();
            // Thêm điều kiện tìm kiếm GẦN ĐÚNG STRING
            if (!string.IsNullOrEmpty(item.TenSuDungDichVu))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(SuDungDichVu.TenSuDungDichVu)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.TenSuDungDichVu)
                );
                expressions.Add(expression);
            }

            if (!string.IsNullOrEmpty(item.NgayBatDau))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(SuDungDichVu.NgayBatDau)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.NgayBatDau)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.NgayKetThuc))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(SuDungDichVu.NgayKetThuc)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.NgayKetThuc)
                );
                expressions.Add(expression);
            }
            // Thêm điều kiện tìm kiếm INT
            if (item.MaSuDungDichVu.HasValue)
            {
                var expression = Expression.Equal(
                    Expression.Property(parameterExpression, nameof(SuDungDichVu.MaSuDungDichVu)),
                    Expression.Constant(item.MaSuDungDichVu, typeof(int?))
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.TrangThai))
            {
                var expression = Expression.Equal(
                    Expression.Property(parameterExpression, nameof(SuDungDichVu.TrangThai)),
                    Expression.Constant(item.TrangThai)
                );
                expressions.Add(expression);
            }
            if (item.MaDichVu.HasValue)
            {
                var expression = Expression.Equal(
                    Expression.Property(parameterExpression, nameof(SuDungDichVu.MaDichVu)),
                    Expression.Constant(item.MaDichVu, typeof(int?))
                );
                expressions.Add(expression);
            }
            if (item.MaTrungTam.HasValue)
            {
                var expression = Expression.Equal(
                    Expression.Property(parameterExpression, nameof(SuDungDichVu.MaTrungTam)),
                    Expression.Constant(item.MaTrungTam, typeof(int?))
                );
                expressions.Add(expression);
            }
            if (item.MaHocSinh.HasValue)
            {
                var expression = Expression.Equal(
                    Expression.Property(parameterExpression, nameof(SuDungDichVu.MaHocSinh)),
                    Expression.Constant(item.MaHocSinh, typeof(int?))
                );
                expressions.Add(expression);
            }
            // Thêm điều kiện Check Ngày Xóa, Người Xóa
            var expressionNgayXoaIsNull = Expression.Equal(Expression.Property(parameterExpression, nameof(SuDungDichVu.NgayXoa)), Expression.Constant(null, typeof(string)));
            expressions.Add(expressionNgayXoaIsNull);

            var expressionNguoiXoaIsNull = Expression.Equal(Expression.Property(parameterExpression, nameof(SuDungDichVu.NguoiXoa)), Expression.Constant(null, typeof(string)));
            expressions.Add(expressionNguoiXoaIsNull);

            var combinedExpression = expressions.Any() ? expressions.Aggregate(Expression.AndAlso) : Expression.Constant(true);
            var lambda = Expression.Lambda<Func<SuDungDichVu, bool>>(combinedExpression, parameterExpression);
            #endregion
            return lambda;
        }

        public object LoadingDataTableView(SuDungDichVu item, int skip, int take)
        {

            var lambda = LambdaSearch(item);
            // Sử dụng biểu thức lambda để lọc dữ liệu từ DbContext và ánh xạ kết quả vào AcademicScore
            var data = _context.SuDungDichVus.Where(lambda).OrderByDescending(n => n.MaSuDungDichVu).Skip(skip).Take(take).Select(x => new
            {
                x.MaSuDungDichVu,
                x.TenSuDungDichVu,
                TenDichVu = x.MaDichVu != null ? _context.DichVus.Where(dv => dv.MaDichVu == x.MaDichVu).Select(dv => dv.TenDichVu).FirstOrDefault() : null,
                x.TrangThai,
                x.NgayKetThuc,
                TenHocSinh = x.MaHocSinh != null ? _context.HocSinhs.Where(hs => hs.MaHocSinh == x.MaHocSinh).Select(hs => hs.TenHocSinh).FirstOrDefault() : null,
            }).ToList();

            int recordsTotal = _context.SuDungDichVus.Where(lambda).Count();
            var jsonData = new { recordsFiltered = recordsTotal, recordsTotal, data };
            return jsonData;
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<ICollection<SuDungDichVu>> Search(SuDungDichVu item)
        {
            var lambda = LambdaSearch(item);

            var filteredResults = await _context.SuDungDichVus.Where(lambda).ToListAsync();
            return filteredResults;
        }

        public async Task<int> SearchCount(SuDungDichVu item)
        {
            var lambda = LambdaSearch(item);
            int numberCount =  _context.SuDungDichVus.Where(lambda).Count();
            return numberCount;
        }

        public async Task<List<object>> SearchName(SuDungDichVu item)
        {
            var lambda = LambdaSearch(item);

            var data = await _context.SuDungDichVus.Where(lambda).OrderByDescending(n => n.MaSuDungDichVu).Select(x => new {
                MaSuDungDichVu = x.MaSuDungDichVu,
                TenSuDungDichVu = x.TenSuDungDichVu
            }).ToListAsync();

            return data.Select(x => new {
                maSuDungDichVu = x.MaSuDungDichVu,
                tenSuDungDichVu = x.TenSuDungDichVu
            }).ToList<object>();
        }

        public Task<bool> Update(SuDungDichVu item)
        {
            if (item != null)
            {
                _context.SuDungDichVus.Update(item);
            }
            return Save();
        }
    }
}
