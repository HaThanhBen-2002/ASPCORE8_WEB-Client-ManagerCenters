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
    public class PhieuThuChiRepon: IPhieuThuChi
    {
        private readonly ApplicationDbContext _context;
        public PhieuThuChiRepon(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CheckId(int id)
        {
            return await _context.PhieuThuChis.AnyAsync(c => c.NgayXoa == null && c.NguoiXoa == null && c.MaPhieu == id);
        }

        public async Task<bool> Create(PhieuThuChi item)
        {
            if (item != null)
            {
                item.MaPhieu = null;
                await _context.PhieuThuChis.AddAsync(item);
            }
            return await Save();
        }

        public Task<bool> Delete(int id, string nguoiXoa, string ngayXoa)
        {
            var itemDelete = _context.PhieuThuChis.Where(c => c.NgayXoa == null && c.NguoiXoa == null && c.MaPhieu == id).FirstOrDefault();
            if (itemDelete != null)
            {
                itemDelete.NguoiXoa = nguoiXoa;
                itemDelete.NgayXoa = ngayXoa;
                _context.PhieuThuChis.Update(itemDelete);
            }
            return Save();
        }

        public async Task<ICollection<PhieuThuChi>> GetAll()
        {
            var allItem = await _context.PhieuThuChis.Where(c => c.NgayXoa == null && c.NguoiXoa == null).ToListAsync();
            return allItem;
        }

        public async Task<PhieuThuChi> GetById(int id)
        {
            var item = await _context.PhieuThuChis.Where(c => c.NgayXoa == null && c.NguoiXoa == null && c.MaPhieu == id).FirstOrDefaultAsync();
            if (item != null)
            {
                return item;
            }
            return new PhieuThuChi();
        }
        private Expression<Func<PhieuThuChi, bool>> LambdaSearch(PhieuThuChi item)
        {
            #region Create Lambda
            var parameterExpression = Expression.Parameter(typeof(PhieuThuChi), "x");
            var expressions = new List<Expression>();
            // Thêm điều kiện tìm kiếm GẦN ĐÚNG STRING
            if (!string.IsNullOrEmpty(item.NgayTao))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(PhieuThuChi.NgayTao)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.NgayTao)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.NgayThanhToan))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(PhieuThuChi.NgayThanhToan)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.NgayThanhToan)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.LoaiPhieu))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(PhieuThuChi.LoaiPhieu)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.LoaiPhieu)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.CodeHoaDon))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(PhieuThuChi.CodeHoaDon)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.CodeHoaDon)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.TongTien))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(PhieuThuChi.TongTien)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.TongTien)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.GhiChu))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(PhieuThuChi.GhiChu)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.GhiChu)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.TrangThai))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(PhieuThuChi.TrangThai)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.TrangThai)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.HinhThucThanhToan))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(PhieuThuChi.HinhThucThanhToan)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.HinhThucThanhToan)
                );
                expressions.Add(expression);
            }
            // Thêm điều kiện tìm kiếm INT
            if (item.MaPhieu.HasValue)
            {
                var expression = Expression.Equal(
                    Expression.Property(parameterExpression, nameof(PhieuThuChi.MaPhieu)),
                    Expression.Constant(item.MaPhieu, typeof(int?))
                );
                expressions.Add(expression);
            }
            if (item.MaNhanVien.HasValue)
            {
                var expression = Expression.Equal(
                    Expression.Property(parameterExpression, nameof(PhieuThuChi.MaNhanVien)),
                    Expression.Constant(item.MaNhanVien, typeof(int?))
                );
                expressions.Add(expression);
            }
            if (item.MaTrungTam.HasValue)
            {
                var expression = Expression.Equal(
                    Expression.Property(parameterExpression, nameof(PhieuThuChi.MaTrungTam)),
                    Expression.Constant(item.MaTrungTam, typeof(int?))
                );
                expressions.Add(expression);
            }
            // Thêm điều kiện Check Ngày Xóa, Người Xóa
            var expressionNgayXoaIsNull = Expression.Equal(Expression.Property(parameterExpression, nameof(PhieuThuChi.NgayXoa)), Expression.Constant(null, typeof(string)));
            expressions.Add(expressionNgayXoaIsNull);

            var expressionNguoiXoaIsNull = Expression.Equal(Expression.Property(parameterExpression, nameof(PhieuThuChi.NguoiXoa)), Expression.Constant(null, typeof(string)));
            expressions.Add(expressionNguoiXoaIsNull);

            var combinedExpression = expressions.Any() ? expressions.Aggregate(Expression.AndAlso) : Expression.Constant(true);
            var lambda = Expression.Lambda<Func<PhieuThuChi, bool>>(combinedExpression, parameterExpression);
            #endregion
            return lambda;
        }
        public object LoadingDataTableView(PhieuThuChi item, int skip, int take)
        {
            var lambda = LambdaSearch(item);

            // Sử dụng biểu thức lambda để lọc dữ liệu từ DbContext và ánh xạ kết quả vào AcademicScore
            var data = _context.PhieuThuChis.Where(lambda).OrderByDescending(n => n.MaPhieu).Skip(skip).Take(take).Select(x => new
            {
                x.MaPhieu,
                x.LoaiPhieu,
                x.TongTien,
                x.NgayTao,
                x.HinhThucThanhToan,
                x.TrangThai
            }).ToList();
            int recordsTotal = _context.PhieuThuChis.Where(lambda).Count();
            var jsonData = new { recordsFiltered = recordsTotal, recordsTotal, data };
            return jsonData;
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<ICollection<PhieuThuChi>> Search(PhieuThuChi item)
        {
            var lambda = LambdaSearch(item);

            var filteredResults = await _context.PhieuThuChis.Where(lambda).ToListAsync();
            return filteredResults;
        }

        public async Task<int> SearchCount(PhieuThuChi item)
        {
            var lambda = LambdaSearch(item);
            return _context.PhieuThuChis.Where(lambda).Count();
        }

        public async Task<double> SearchTongTien(PhieuThuChi item)
        {
            var lambda = LambdaSearch(item);

            // Sử dụng biểu thức lambda để lọc dữ liệu từ DbContext và ánh xạ kết quả vào AcademicScore
            var data = _context.PhieuThuChis.Where(lambda).OrderByDescending(n => n.MaPhieu).Select(x => new
            {
                x.TongTien
            }).ToList();
            double tongTien = 0;
            foreach(var n in data)
            {
                tongTien += Convert.ToDouble(n.TongTien);
            }
            return tongTien;
        }

        public Task<bool> Update(PhieuThuChi item)
        {
            if (item != null)
            {
                _context.PhieuThuChis.Update(item);
            }
            return Save();
        }   
    }
}
