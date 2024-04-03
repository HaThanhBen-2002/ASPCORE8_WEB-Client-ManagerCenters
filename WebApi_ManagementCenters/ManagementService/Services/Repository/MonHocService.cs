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
{using static ManagementService.Support.Support;
    public class MonHocService: IMonHocService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MonHocService(IUnitOfWork unitOfWork, IMapper mapper)
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
                    return await _unitOfWork.MonHoc.CheckId(id);
                }
                return false;
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> Create(MonHocDto item)
        {
            try
            {
                if (item != null)
                {
                    // Chuyển đổi TrungTamDto thành TrungTam bằng AutoMapper
                    var trungTam = _mapper.Map<MonHoc>(item);

                    // Kiểm tra hợp lệ của đối tượng TrungTam
                    var validationResults = new List<ValidationResult>();
                    var isValid = Validator.TryValidateObject(trungTam, new ValidationContext(trungTam), validationResults, true);

                    if (!isValid)
                    {
                        // Nếu dữ liệu không hợp lệ, trả về false
                        return false;
                    }
                    return await _unitOfWork.MonHoc.Create(_mapper.Map<MonHoc>(item));
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
                    return await _unitOfWork.MonHoc.Delete(id, nguoiXoa, GetCurrentDateTime());
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ICollection<MonHocDto>> GetAll()
        {
            try
            {
                return _mapper.Map<List<MonHocDto>>(await _unitOfWork.MonHoc.GetAll());
            }
            catch
            {
                return new List<MonHocDto>();
            }
        }

        public async Task<MonHocDto> GetById(int id)
        {
            try
            {
                if (id != 0)
                {
                    return _mapper.Map<MonHocDto>(await _unitOfWork.MonHoc.GetById(id));
                }
                return new MonHocDto();
            }
            catch
            {
                return new MonHocDto();
            }
        }

        public object LoadingDataTableView(MonHocDto item, int skip, int take)
        {
            try
            {
                if (item != null)
                {
                    return _unitOfWork.MonHoc.LoadingDataTableView(_mapper.Map<MonHoc>(item), skip, take);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ICollection<MonHocDto>> Search(MonHocDto item)
        {
            try
            {
                if (item != null)
                {
                    return _mapper.Map<List<MonHocDto>>(await _unitOfWork.MonHoc.Search(_mapper.Map<MonHoc>(item)));
                }
                return new List<MonHocDto>();
            }
            catch
            {
                return new List<MonHocDto>();
            }
        }

        public async Task<int> SearchCount(MonHocDto item)
        {
            try
            {
                if (item != null)
                {
                    return await _unitOfWork.MonHoc.SearchCount(_mapper.Map<MonHoc>(item));
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<List<object>> SearchName(MonHocDto item)
        {
            try
            {
                if (item != null)
                {
                    return await _unitOfWork.MonHoc.SearchName(_mapper.Map<MonHoc>(item));
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> Update(MonHocDto item)
        {
            try
            {
                if (item != null)
                {
                    // Chuyển đổi TrungTamDto thành TrungTam bằng AutoMapper
                    var trungTam = _mapper.Map<MonHoc>(item);

                    // Kiểm tra hợp lệ của đối tượng TrungTam
                    var validationResults = new List<ValidationResult>();
                    var isValid = Validator.TryValidateObject(trungTam, new ValidationContext(trungTam), validationResults, true);

                    if (!isValid)
                    {
                        // Nếu dữ liệu không hợp lệ, trả về false
                        return false;
                    }
                    return await _unitOfWork.MonHoc.Update(_mapper.Map<MonHoc>(item));
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
