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
    public class MonHocRepon: IMonHoc
    {
        private readonly ApplicationDbContext _context;
        public MonHocRepon(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckId(int id)
        {
            return await _context.MonHocs.AnyAsync(c => c.NgayXoa == null && c.NguoiXoa == null && c.MaMonHoc == id);
        }

        public async Task<bool> Create(MonHoc item)
        {
            if (item != null)
            {
                item.MaMonHoc = null;
                await _context.MonHocs.AddAsync(item);
            }
            return await Save();
        }

        public Task<bool> Delete(int id, string nguoiXoa, string ngayXoa)
        {
            var itemDelete = _context.MonHocs.Where(c => c.NgayXoa == null && c.NguoiXoa == null && c.MaMonHoc == id).FirstOrDefault();
            if (itemDelete != null)
            {
                itemDelete.NguoiXoa = nguoiXoa;
                itemDelete.NgayXoa = ngayXoa;
                _context.MonHocs.Update(itemDelete);
            }
            return Save();
        }

        public async Task<ICollection<MonHoc>> GetAll()
        {
            var allItem = await _context.MonHocs.Where(c => c.NgayXoa == null && c.NguoiXoa == null).ToListAsync();
            return allItem;
        }

        public async Task<MonHoc> GetById(int id)
        {
            var item = await _context.MonHocs.Where(c => c.NgayXoa == null && c.NguoiXoa == null && c.MaMonHoc == id).FirstOrDefaultAsync();
            if (item != null)
            {
                return item;
            }
            return new MonHoc();
        }

        private Expression<Func<MonHoc, bool>> LambdaSearch(MonHoc item)
        {
            #region Create Lambda
            var parameterExpression = Expression.Parameter(typeof(MonHoc), "x");
            var expressions = new List<Expression>();
            // Thêm điều kiện tìm kiếm GẦN ĐÚNG STRING
            if (!string.IsNullOrEmpty(item.TenMonHoc))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(MonHoc.TenMonHoc)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.TenMonHoc)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.Gia))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(MonHoc.Gia)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.Gia)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.ThongTin))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(MonHoc.ThongTin)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.ThongTin)
                );
                expressions.Add(expression);
            }
            // Thêm điều kiện tìm kiếm INT
            if (item.MaMonHoc.HasValue)
            {
                var expression = Expression.Equal(
                    Expression.Property(parameterExpression, nameof(MonHoc.MaMonHoc)),
                    Expression.Constant(item.MaMonHoc, typeof(int?))
                );
                expressions.Add(expression);
            }
            // Thêm điều kiện Check Ngày Xóa, Người Xóa
            var expressionNgayXoaIsNull = Expression.Equal(Expression.Property(parameterExpression, nameof(MonHoc.NgayXoa)), Expression.Constant(null, typeof(string)));
            expressions.Add(expressionNgayXoaIsNull);

            var expressionNguoiXoaIsNull = Expression.Equal(Expression.Property(parameterExpression, nameof(MonHoc.NguoiXoa)), Expression.Constant(null, typeof(string)));
            expressions.Add(expressionNguoiXoaIsNull);

            var combinedExpression = expressions.Any() ? expressions.Aggregate(Expression.AndAlso) : Expression.Constant(true);
            var lambda = Expression.Lambda<Func<MonHoc, bool>>(combinedExpression, parameterExpression);
            #endregion
            return lambda;
        }

        public object LoadingDataTableView(MonHoc item, int skip, int take)
        {

            var lambda = LambdaSearch(item);
            // Sử dụng biểu thức lambda để lọc dữ liệu từ DbContext và ánh xạ kết quả vào AcademicScore
            var data = _context.MonHocs.Where(lambda).OrderByDescending(n => n.MaMonHoc).Skip(skip).Take(take).Select(x => new
            {
                x.MaMonHoc,
                x.TenMonHoc,
                x.Gia,
                x.ThongTin,
            }).ToList();
            int recordsTotal = _context.MonHocs.Where(lambda).Count();
            var jsonData = new { recordsFiltered = recordsTotal, recordsTotal, data };
            return jsonData;
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<ICollection<MonHoc>> Search(MonHoc item)
        {
            var lambda = LambdaSearch(item);

            var filteredResults = await _context.MonHocs.Where(lambda).ToListAsync();
            return filteredResults;
        }

        public async Task<int> SearchCount(MonHoc item)
        {
            var lambda = LambdaSearch(item);
            return _context.MonHocs.Where(lambda).Count();
        }

        public async Task<List<object>> SearchName(MonHoc item)
        {
            var lambda = LambdaSearch(item);
            // Sử dụng biểu thức lambda để lọc dữ liệu từ DbContext và ánh xạ kết quả vào AcademicScore
            var data = await _context.MonHocs.Where(lambda).OrderByDescending(n => n.MaMonHoc).Select(x => new {
                MaMonHoc = x.MaMonHoc,
                TenMonHoc = x.TenMonHoc
            }).ToListAsync();

            return data.Select(x => new {
                maMonHoc = x.MaMonHoc,
                tenMonHoc = x.TenMonHoc
            }).ToList<object>();
        }

        public Task<bool> Update(MonHoc item)
        {
            if (item != null)
            {
                _context.MonHocs.Update(item);
            }
            return Save();
        }
    }
}
