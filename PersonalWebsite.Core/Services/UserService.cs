using Microsoft.AspNetCore.Http;
using PersonalWebsite.Core.Convertors;
using PersonalWebsite.Core.DTOs;
using PersonalWebsite.Core.DTOs.Project;
using PersonalWebsite.Core.DTOs.Resume;
using PersonalWebsite.Core.Generator;
using PersonalWebsite.Core.Secutiry;
using PersonalWebsite.Core.Services.Interfaces;
using PersonalWebsite.DataLayer.Context;
using PersonalWebsite.DataLayer.Entities.User;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TopLearn.Core.Security;

namespace PersonalWebsite.Core.Services
{
    public class UserService : IUserService
    {
        private PersonalWebsiteContext _context;

        public UserService(PersonalWebsiteContext context)
        {
            _context = context;
        }

        public void AddContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }

        public int AddDegree(Degree degree)
        {
            _context.Degrees.Add(degree);
            _context.SaveChanges();

            return degree.DegreeId;
        }

        public int AddEducation(Education education)
        {
            _context.Educations.Add(education);
            _context.SaveChanges();

            return education.EducationID;
        }

        public int AddExperience(Experience experience)
        {
            _context.Experiences.Add(experience);
            _context.SaveChanges();

            return experience.ExperienceID;
        }

        public int AddProject(Project project, IFormFile imgProject)
        {
            project.ProjectImage = "no-photo.jpg";

            //TODO Check Image
            if (imgProject != null && imgProject.IsImage())
            {
                project.ProjectImage = NameGenerator.GenerateUniqCode() + Path.GetExtension(imgProject.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/project/image", project.ProjectImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgProject.CopyTo(stream);
                }

                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/project/thumb", project.ProjectImage);

                imgResizer.Image_resize(imagePath, thumbPath, 500);
            }

            _context.Add(project);
            _context.SaveChanges();

            return project.ProjectID;
        }

        public int AddSkill(Skill skill)
        {
            _context.Add(skill);
            _context.SaveChanges();

            return skill.SkillID;
        }

        public void DeleteContact(int contactId)
        {
            Contact contact = GetContactById(contactId);

            _context.Contacts.Remove(contact);
            _context.SaveChanges();
        }

        public void DeleteDegree(int degreeId)
        {
            Degree degree = GetDegreeById(degreeId);

            _context.Degrees.Remove(degree);
            _context.SaveChanges();
        }

        public void DeleteEducation(int educationId)
        {
            Education education = GetEducationById(educationId);

            _context.Educations.Remove(education);
            _context.SaveChanges();
        }

        public void DeleteExperience(int experienceId)
        {
            Experience experience = GetExperienceById(experienceId);

            _context.Experiences.Remove(experience);
            _context.SaveChanges();
        }

        public void DeleteSkill(int skillId)
        {
            Skill skill = GetSkillById(skillId);

            _context.Skills.Remove(skill);
            _context.SaveChanges();
        }

        public void DeletProject(int projectId)
        {
            Project project = GetProjectById(projectId);
            if (project.ProjectImage != "no-photo.jpg")
            {
                string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/project/image", project.ProjectImage);
                if (File.Exists(deleteimagePath))
                {
                    File.Delete(deleteimagePath);
                }

                string deletethumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/project/thumb", project.ProjectImage);
                if (File.Exists(deletethumbPath))
                {
                    File.Delete(deletethumbPath);
                }
            }
            _context.Projects.Remove(project);
            _context.SaveChanges();
        }

        public void EditUserFromAdmin(EditUserViewModel editUser)
        {
            User user = GetUserById(editUser.UserId);
            user.Email = editUser.Email;
            if (!string.IsNullOrEmpty(editUser.Password))
            {
                user.Password = editUser.Password;
            }

            if (editUser.UserImage != null)
            {
                //Delete old Image
                if (editUser.ImageName != "Defult.jpg")
                {
                    string deletePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserImage", editUser.ImageName);
                    if (File.Exists(deletePath))
                    {
                        File.Delete(deletePath);
                    }
                }

                //Save New Image
                user.UserImage = NameGenerator.GenerateUniqCode() + Path.GetExtension(editUser.UserImage.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserImage", user.UserImage);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    editUser.UserImage.CopyTo(stream);
                }
            }

            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public AboutUser GetAboutUserById(int au_Id)
        {
            return _context.AboutUsers.Find(au_Id);
        }

        public List<AboutUser> GetAboutUsersForAdmin()
        {
            return _context.AboutUsers.ToList();
        }

        public Contact GetContactById(int contactId)
        {
            return _context.Contacts.Find(contactId);
        }

        public int GetContactCount()
        {
            return _context.Contacts.Count();
        }

        public Tuple<List<Contact>, int> GetContactForAdmin(int pageId = 1, int take = 0)
        {
            if (take == 0)
            {
                take = 6;
            }

            //IQueryable<Contact> result = _context.Contacts;

            int skip = (pageId - 1) * take;

            int pageCount = _context.Contacts.OrderByDescending(c => c.CreateDate).Count() / take;
            if ((pageCount % 2) != 0)
            {
                pageCount += 1;
            }

            var query = _context.Contacts.OrderByDescending(c => c.CreateDate).Skip(skip).Take(take).ToList();

            return Tuple.Create(query, pageCount);
            //return _context.Contacts.ToList();
        }

        public Degree GetDegreeById(int degreeId)
        {
            return _context.Degrees.Find(degreeId);
        }

        public Degree GetDegreeInformation(int degreeId)
        {
            return _context.Degrees.Find(degreeId);
        }

        public List<Degree> GetDegreesForAdmin()
        {
            return _context.Degrees.ToList();
        }

        public Education GetEducationById(int educationId)
        {
            return _context.Educations.Find(educationId);
        }

        public Education GetEducationInformation(int educationId)
        {
            return _context.Educations.Find(educationId);
        }

        public List<Education> GetEducationsForAdmin()
        {
            return _context.Educations.ToList();
        }

        public Experience GetExperienceById(int experienceId)
        {
            return _context.Experiences.Find(experienceId);
        }

        public Experience GetExperienceInformation(int experienceId)
        {
            return _context.Experiences.Find(experienceId);
        }

        public List<Experience> GetExperiencesForAdmin()
        {
            return _context.Experiences.ToList();
        }

        public Project GetProjectById(int projectId)
        {
            return _context.Projects.Find(projectId);
        }

        public ShowProjectsForAdminViewModel GetProjectInformation(int projectId)
        {
            var project = GetProjectById(projectId);
            ShowProjectsForAdminViewModel projectContent = new ShowProjectsForAdminViewModel();
            projectContent.Title = project.Title;
            projectContent.ProjectDate = project.ProjectDate;
            projectContent.SDescription = project.SDescription;
            projectContent.ProjectImage = project.ProjectImage;

            return projectContent;
        }

        public Tuple<List<ShowProjectListItemViewModel>, int> GetProjectList(int pageId = 1, int take = 0)
        {
            if (take == 0)
            {
                take = 6;
            }

            IQueryable<Project> result = _context.Projects;

            int skip = (pageId - 1) * take;

            int pageCount = result.Select(p => new ShowProjectListItemViewModel()
            {
                ProjectId = p.ProjectID,
                Title = p.Title,
                ProjectImage = p.ProjectImage,
                SDescription = p.SDescription
            }).OrderByDescending(p => p.ProjectId).Count() / take;
            if ((pageCount % 2) != 0)
            {
                pageCount += 1;
            }

            var query = result.Select(p => new ShowProjectListItemViewModel()
            {
                ProjectId = p.ProjectID,
                Title = p.Title,
                ProjectImage = p.ProjectImage,
                SDescription = p.SDescription
            }).OrderByDescending(p => p.ProjectId).Skip(skip).Take(take).ToList();

            return Tuple.Create(query, pageCount);
        }

        public List<ShowProjectsForAdminViewModel> GetProjectsForAdmin()
        {
            return _context.Projects.Select(p => new ShowProjectsForAdminViewModel()
            {
                ProjectID = p.ProjectID,
                ProjectImage = p.ProjectImage,
                Title = p.Title,
                SDescription = p.SDescription,
                ProjectDate = p.ProjectDate
            }).ToList();
        }

        public Skill GetSkillById(int skillId)
        {
            return _context.Skills.Find(skillId);
        }

        public Skill GetSkillInformation(int skillId)
        {
            var skill = GetSkillById(skillId);
            Skill skillInfo = new Skill();
            skillInfo.Title = skill.Title;
            skillInfo.Percent = skill.Percent;

            return skillInfo;
        }

        public List<Skill> GetSkillsForAdmin()
        {
            return _context.Skills.ToList();
        }

        public User GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }

        public EditUserViewModel GetUserForShowInEditMode(int userId)
        {
            return _context.Users.Where(u => u.UserId == userId)
                .Select(u => new EditUserViewModel()
                {
                    UserId = u.UserId,
                    ImageName = u.UserImage,
                    Username = u.Username,
                    Email = u.Email
                }).Single();
        }

        public List<User> GetUsers()
        {
            IQueryable<User> result = _context.Users;
            return result.ToList();
        }

        public User LoginUser(LoginViewModel login)
        {
            return _context.Users.SingleOrDefault(u => u.Username == login.Username
                                        && u.Password == login.Password);
        }

        public void UpdateAboutUser(AboutUser aboutUser, IFormFile imgProfile)
        {
            if (imgProfile != null && imgProfile.IsImage())
            {
                if (aboutUser.ImageProfile != "Defult.jpg")
                {
                    string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserProfile", aboutUser.ImageProfile);
                    if (File.Exists(deleteimagePath))
                    {
                        File.Delete(deleteimagePath);
                    }
                }
                aboutUser.ImageProfile = NameGenerator.GenerateUniqCode() + Path.GetExtension(imgProfile.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserProfile", aboutUser.ImageProfile);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgProfile.CopyTo(stream);
                }
            }

            _context.AboutUsers.Update(aboutUser);
            _context.SaveChanges();
        }

        public void UpdateDegree(Degree degree)
        {
            _context.Degrees.Update(degree);
            _context.SaveChanges();
        }

        public void UpdateEducation(Education education)
        {
            _context.Educations.Update(education);
            _context.SaveChanges();
        }

        public void UpdateExperience(Experience experience)
        {
            _context.Experiences.Update(experience);
            _context.SaveChanges();
        }

        public void UpdateProject(Project project, IFormFile imgProject)
        {
            if (imgProject != null && imgProject.IsImage())
            {
                if (project.ProjectImage != "no-photo.jpg")
                {
                    string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/project/image", project.ProjectImage);
                    if (File.Exists(deleteimagePath))
                    {
                        File.Delete(deleteimagePath);
                    }

                    string deletethumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/project/thumb", project.ProjectImage);
                    if (File.Exists(deletethumbPath))
                    {
                        File.Delete(deletethumbPath);
                    }
                }
                project.ProjectImage = NameGenerator.GenerateUniqCode() + Path.GetExtension(imgProject.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/project/image", project.ProjectImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgProject.CopyTo(stream);
                }

                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/project/thumb", project.ProjectImage);

                imgResizer.Image_resize(imagePath, thumbPath, 250);
            }

            _context.Projects.Update(project);
            _context.SaveChanges();
        }

        public void UpdateSkill(Skill skill)
        {
            _context.Skills.Update(skill);
            _context.SaveChanges();
        }
    }
}
