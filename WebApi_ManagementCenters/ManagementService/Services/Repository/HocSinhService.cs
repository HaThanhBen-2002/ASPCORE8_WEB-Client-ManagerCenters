using AutoMapper;
using Data.Dtos;
using Data.InterfacesData;
using Data.Models;
using Data.Models.ModelView;
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
    public class HocSinhService: IHocSinhService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public HocSinhService(IUnitOfWork unitOfWork, IMapper mapper)
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
                    return await _unitOfWork.HocSinh.CheckId(id);
                }
                return false;
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> Create(HocSinhDto item)
        {
            try
            {
                if (item != null)
                {
                    // Chuyển đổi TrungTamDto thành TrungTam bằng AutoMapper
                    var trungTam = _mapper.Map<HocSinh>(item);

                    // Kiểm tra hợp lệ của đối tượng TrungTam
                    var validationResults = new List<ValidationResult>();
                    var isValid = Validator.TryValidateObject(trungTam, new ValidationContext(trungTam), validationResults, true);

                    if (!isValid)
                    {
                        // Nếu dữ liệu không hợp lệ, trả về false
                        return false;
                    }
                    return await _unitOfWork.HocSinh.Create(_mapper.Map<HocSinh>(item));
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
                    return await _unitOfWork.HocSinh.Delete(id, nguoiXoa, GetCurrentDateTime());
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ICollection<HocSinhDto>> GetAll()
        {
            try
            {
                return _mapper.Map<List<HocSinhDto>>(await _unitOfWork.HocSinh.GetAll());
            }
            catch
            {
                return new List<HocSinhDto>();
            }
        }

        public async Task<HocSinhDto> GetById(int id)
        {
            try
            {
                if (id != 0)
                {
                    return _mapper.Map<HocSinhDto>(await _unitOfWork.HocSinh.GetById(id));
                }
                return new HocSinhDto();
            }
            catch
            {
                return new HocSinhDto();
            }
        }

        public async Task<HocSinhView> GetHocSinhView(int id)
        {
            try
            {
                if (id != 0)
                {
                    return await _unitOfWork.HocSinh.GetHocSinhView(id);
                }
                return new HocSinhView();
            }
            catch
            {
                return new HocSinhView();
            }
        }

        public object LoadingDataTableView(HocSinhDto item, int skip, int take)
        {
            try
            {
                if (item != null)
                {
                    return _unitOfWork.HocSinh.LoadingDataTableView(_mapper.Map<HocSinh>(item), skip, take);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ICollection<HocSinhDto>> Search(HocSinhDto item)
        {
            try
            {
                if (item != null)
                {
                    return _mapper.Map<List<HocSinhDto>>(await _unitOfWork.HocSinh.Search(_mapper.Map<HocSinh>(item)));
                }
                return new List<HocSinhDto>();
            }
            catch
            {
                return new List<HocSinhDto>();
            }
        }

        public async Task<int> SearchCount(HocSinhDto item)
        {
            try
            {
                if (item != null)
                {
                    return await _unitOfWork.HocSinh.SearchCount(_mapper.Map<HocSinh>(item));
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<List<object>> SearchName(HocSinhDto item)
        {
            try
            {
                if (item != null)
                {
                    return await _unitOfWork.HocSinh.SearchName(_mapper.Map<HocSinh>(item));
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> Update(HocSinhDto item)
        {
            try
            {
                if (item != null)
                {
                    // Chuyển đổi TrungTamDto thành TrungTam bằng AutoMapper
                    var trungTam = _mapper.Map<HocSinh>(item);

                    // Kiểm tra hợp lệ của đối tượng TrungTam
                    var validationResults = new List<ValidationResult>();
                    var isValid = Validator.TryValidateObject(trungTam, new ValidationContext(trungTam), validationResults, true);

                    if (!isValid)
                    {
                        // Nếu dữ liệu không hợp lệ, trả về false
                        return false;
                    }
                    return await _unitOfWork.HocSinh.Update(_mapper.Map<HocSinh>(item));
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
