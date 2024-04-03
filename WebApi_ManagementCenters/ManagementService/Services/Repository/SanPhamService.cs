using AutoMapper;
using Data.Dtos;
using Data.InterfacesData;
using Data.Models;
using ManagementService.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ManagementService.Support.Support;
namespace ManagementService.Services.Repository
{
    public class SanPhamService: ISanPhamService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SanPhamService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CheckId(int id)
        {
            try
            {
                if (id != 0)
                {
                    return await _unitOfWork.SanPham.CheckId(id);
                }
                return false;
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> Create(SanPhamDto item)
        {
            try
            {
                if (item != null)
                {
                    // Chuyển đổi TrungTamDto thành TrungTam bằng AutoMapper
                    var trungTam = _mapper.Map<SanPham>(item);

                    // Kiểm tra hợp lệ của đối tượng TrungTam
                    var validationResults = new List<ValidationResult>();
                    var isValid = Validator.TryValidateObject(trungTam, new ValidationContext(trungTam), validationResults, true);

                    if (!isValid)
                    {
                        // Nếu dữ liệu không hợp lệ, trả về false
                        return false;
                    }
                    return await _unitOfWork.SanPham.Create(_mapper.Map<SanPham>(item));
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id, string nguoiXoa)
        {
            try
            {
                if (id != 0 && nguoiXoa != null)
                {
                    return await _unitOfWork.SanPham.Delete(id, nguoiXoa, GetCurrentDateTime());
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ICollection<SanPhamDto>> GetAll()
        {
            try
            {
                return _mapper.Map<List<SanPhamDto>>(await _unitOfWork.SanPham.GetAll());
            }
            catch
            {
                return new List<SanPhamDto>();
            }
        }

        public async Task<SanPhamDto> GetById(int id)
        {
            try
            {
                if (id != 0)
                {
                    return _mapper.Map<SanPhamDto>(await _unitOfWork.SanPham.GetById(id));
                }
                return new SanPhamDto();
            }
            catch
            {
                return new SanPhamDto();
            }
        }

        public object LoadingDataTableView(SanPhamDto item, int skip, int take)
        {
            try
            {
                if (item != null)
                {
                    return _unitOfWork.SanPham.LoadingDataTableView(_mapper.Map<SanPham>(item), skip, take);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ICollection<SanPhamDto>> Search(SanPhamDto item)
        {
            try
            {
                if (item != null)
                {
                    return _mapper.Map<List<SanPhamDto>>(await _unitOfWork.SanPham.Search(_mapper.Map<SanPham>(item)));
                }
                return new List<SanPhamDto>();
            }
            catch
            {
                return new List<SanPhamDto>();
            }
        }

        public async Task<int> SearchCount(SanPhamDto item)
        {
            try
            {
                if (item != null)
                {
                    return await _unitOfWork.SanPham.SearchCount(_mapper.Map<SanPham>(item));
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<List<object>> SearchName(SanPhamDto item)
        {
            try
            {
                if (item != null)
                {
                    return await _unitOfWork.SanPham.SearchName(_mapper.Map<SanPham>(item));
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> Update(SanPhamDto item)
        {
            try
            {
                if (item != null)
                {
                    // Chuyển đổi TrungTamDto thành TrungTam bằng AutoMapper
                    var trungTam = _mapper.Map<SanPham>(item);

                    // Kiểm tra hợp lệ của đối tượng TrungTam
                    var validationResults = new List<ValidationResult>();
                    var isValid = Validator.TryValidateObject(trungTam, new ValidationContext(trungTam), validationResults, true);

                    if (!isValid)
                    {
                        // Nếu dữ liệu không hợp lệ, trả về false
                        return false;
                    }
                    return await _unitOfWork.SanPham.Update(_mapper.Map<SanPham>(item));
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
