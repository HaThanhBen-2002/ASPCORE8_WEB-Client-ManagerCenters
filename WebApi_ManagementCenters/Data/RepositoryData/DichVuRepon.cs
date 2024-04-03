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
    public class DichVuRepon : IDichVu
    {
        private readonly ApplicationDbContext _context;
        public DichVuRepon(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckId(int id)
        {
            return await _context.DichVus.AnyAsync(c => c.NgayXoa == null && c.NguoiXoa == null && c.MaDichVu == id);
        }

        public async Task<bool> Create(DichVu item)
        {
            if (item != null)
            {
                item.MaDichVu = null;
                await _context.DichVus.AddAsync(item);
            }
            return await Save();
        }

        public Task<bool> Delete(int id, string nguoiXoa, string ngayXoa)
        {
            var itemDelete = _context.DichVus.Where(c => c.NgayXoa == null && c.NguoiXoa == null && c.MaDichVu == id).FirstOrDefault();
            if (itemDelete != null)
            {
                itemDelete.NguoiXoa = nguoiXoa;
                itemDelete.NgayXoa = ngayXoa;
                _context.DichVus.Update(itemDelete);
            }
            return Save();
        }

        public async Task<ICollection<DichVu>> GetAll()
        {
            var allItem = await _context.DichVus.Where(c => c.NgayXoa == null && c.NguoiXoa == null).ToListAsync();
            return allItem;
        }

        public async Task<DichVu> GetById(int id)
        {
            var item = await _context.DichVus.Where(c => c.NgayXoa == null && c.NguoiXoa == null && c.MaDichVu == id).FirstOrDefaultAsync();
            if (item != null)
            {
                return item;
            }
            return new DichVu();
        }

        private Expression<Func<DichVu, bool>> LambdaSearch(DichVu item)
        {
            #region Create Lambda
            var parameterExpression = Expression.Parameter(typeof(DichVu), "x");
            var expressions = new List<Expression>();
            // Thêm điều kiện tìm kiếm GẦN ĐÚNG STRING
            if (!string.IsNullOrEmpty(item.TenDichVu))
            {
                // Tạo biểu thức so sánh cho ScoreName
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(DichVu.TenDichVu)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.TenDichVu)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.ThongTin))
            {
                // Tạo biểu thức so sánh cho ScoreName
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(DichVu.ThongTin)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.ThongTin)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.Gia))
            {
                // Tạo biểu thức so sánh cho ScoreName
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(DichVu.Gia)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.Gia)
                );
                expressions.Add(expression);
            }
            // Thêm điều kiện tìm kiếm INT
            if (item.MaDichVu.HasValue)
            {
                var expression = Expression.Equal(
                    Expression.Property(parameterExpression, nameof(DichVu.MaDichVu)),
                    Expression.Constant(item.MaDichVu, typeof(int?))
                );
                expressions.Add(expression);
            }
            // Thêm điều kiện Check Ngày Xóa, Người Xóa
            var expressionNgayXoaIsNull = Expression.Equal(Expression.Property(parameterExpression, nameof(DichVu.NgayXoa)), Expression.Constant(null, typeof(string)));
            expressions.Add(expressionNgayXoaIsNull);

            var expressionNguoiXoaIsNull = Expression.Equal(Expression.Property(parameterExpression, nameof(DichVu.NguoiXoa)), Expression.Constant(null, typeof(string)));
            expressions.Add(expressionNguoiXoaIsNull);

            var combinedExpression = expressions.Any() ? expressions.Aggregate(Expression.AndAlso) : Expression.Constant(true);
            var lambda = Expression.Lambda<Func<DichVu, bool>>(combinedExpression, parameterExpression);
            #endregion
            return lambda;
        }

        public object LoadingDataTableView(DichVu item, int skip, int take)
        {
            var lambda = LambdaSearch(item);

            // Sử dụng biểu thức lambda để lọc dữ liệu từ DbContext và ánh xạ kết quả vào AcademicScore
            var data = _context.DichVus.Where(lambda).OrderByDescending(n =>n.MaDichVu).Skip(skip).Take(take).Select(x => new
            {
                x.MaDichVu,
                x.TenDichVu,
                x.Gia,
            }).ToList();
            int recordsTotal = _context.DichVus.Where(lambda).Count();
            var jsonData = new { recordsFiltered = recordsTotal, recordsTotal, data };
            return jsonData;
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<ICollection<DichVu>> Search(DichVu item)
        {
            var lambda = LambdaSearch(item);

            var filteredResults = await _context.DichVus.Where(lambda).ToListAsync();
            return filteredResults;
        }

        public async Task<int> SearchCount(DichVu item)
        {
            var lambda = LambdaSearch(item);
            return _context.DichVus.Where(lambda).Count();
        }

        public async Task<List<object>> SearchName(DichVu item)
        {
            var lambda = LambdaSearch(item);


            // Sử dụng biểu thức lambda để lọc dữ liệu từ DbContext và ánh xạ kết quả vào AcademicScore
            var data = await _context.DichVus.Where(lambda).OrderByDescending(n => n.MaDichVu).Select(x => new {
                MaDichVu = x.MaDichVu,
                TenDichVu = x.TenDichVu
            }).ToListAsync();

            return data.Select(x => new {
                maDichVu = x.MaDichVu,
                tenDichVu = x.TenDichVu
            }).ToList<object>();
        }

        public Task<bool> Update(DichVu item)
        {
            if (item != null)
            {
                _context.DichVus.Update(item);
            }
            return Save();
        }
    }
}
