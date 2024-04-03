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
    public class DichVuService: IDichVuService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DichVuService(IUnitOfWork unitOfWork, IMapper mapper)
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
                    return await _unitOfWork.DichVu.CheckId(id);
                }
                return false;
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> Create(DichVuDto item)
        {
            try
            {
                if (item != null)
                {
                    // Chuyển đổi TrungTamDto thành TrungTam bằng AutoMapper
                    var trungTam = _mapper.Map<DichVu>(item);

                    // Kiểm tra hợp lệ của đối tượng TrungTam
                    var validationResults = new List<ValidationResult>();
                    var isValid = Validator.TryValidateObject(trungTam, new ValidationContext(trungTam), validationResults, true);

                    if (!isValid)
                    {
                        // Nếu dữ liệu không hợp lệ, trả về false
                        return false;
                    }
                    return await _unitOfWork.DichVu.Create(_mapper.Map<DichVu>(item));
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
                    return await _unitOfWork.DichVu.Delete(id, nguoiXoa, GetCurrentDateTime());
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ICollection<DichVuDto>> GetAll()
        {
            try
            {
                return _mapper.Map<List<DichVuDto>>(await _unitOfWork.DichVu.GetAll());
            }
            catch
            {
                return new List<DichVuDto>();
            }
        }

        public async Task<DichVuDto> GetById(int id)
        {
            try
            {
                if (id != 0)
                {
                    return _mapper.Map<DichVuDto>(await _unitOfWork.DichVu.GetById(id));
                }
                return new DichVuDto();
            }
            catch
            {
                return new DichVuDto();
            }
        }

        public object LoadingDataTableView(DichVuDto item, int skip, int take)
        {
            try
            {
                if (item != null)
                {
                    return _unitOfWork.DichVu.LoadingDataTableView(_mapper.Map<DichVu>(item), skip, take);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ICollection<DichVuDto>> Search(DichVuDto item)
        {
            try
            {
                if (item != null)
                {
                    return _mapper.Map<List<DichVuDto>>(await _unitOfWork.DichVu.Search(_mapper.Map<DichVu>(item)));
                }
                return new List<DichVuDto>();
            }
            catch
            {
                return new List<DichVuDto>();
            }
        }

        public async Task<int> SearchCount(DichVuDto item)
        {
            try
            {
                if (item != null)
                {
                    return await _unitOfWork.DichVu.SearchCount(_mapper.Map<DichVu>(item));
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<List<object>> SearchName(DichVuDto item)
        {
            try
            {
                if (item != null)
                {
                    return await _unitOfWork.DichVu.SearchName(_mapper.Map<DichVu>(item));
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> Update(DichVuDto item)
        {
            try
            {
                if (item != null)
                {
                    // Chuyển đổi TrungTamDto thành TrungTam bằng AutoMapper
                    var trungTam = _mapper.Map<DichVu>(item);

                    // Kiểm tra hợp lệ của đối tượng TrungTam
                    var validationResults = new List<ValidationResult>();
                    var isValid = Validator.TryValidateObject(trungTam, new ValidationContext(trungTam), validationResults, true);

                    if (!isValid)
                    {
                        // Nếu dữ liệu không hợp lệ, trả về false
                        return false;
                    }
                    return await _unitOfWork.DichVu.Update(_mapper.Map<DichVu>(item));
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
