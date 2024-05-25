using Microsoft.AspNetCore.Http;
using PersonalWebsite.Core.DTOs;
using PersonalWebsite.Core.DTOs.Project;
using PersonalWebsite.Core.DTOs.Resume;
using PersonalWebsite.DataLayer.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalWebsite.Core.Services.Interfaces
{
    public interface IUserService
    {
        #region User

        User LoginUser(LoginViewModel login);
        User GetUserById(int userId);
        List<User> GetUsers();
        EditUserViewModel GetUserForShowInEditMode(int userId);
        void EditUserFromAdmin(EditUserViewModel editUser);

        #endregion

        #region AboutUser

        List<AboutUser> GetAboutUsersForAdmin();

        AboutUser GetAboutUserById(int au_Id);

        void UpdateAboutUser(AboutUser aboutUser, IFormFile imgProfile);
        #endregion

        #region Skills

        List<Skill> GetSkillsForAdmin();

        int AddSkill(Skill skill);

        Skill GetSkillById(int skillId);

        void UpdateSkill(Skill skill);

        Skill GetSkillInformation(int skillId);

        void DeleteSkill(int skillId);

        #endregion

        #region Educations

        List<Education> GetEducationsForAdmin();

        int AddEducation(Education education);

        Education GetEducationById(int educationId);

        void UpdateEducation(Education education);

        Education GetEducationInformation(int educationId);

        void DeleteEducation(int educationId);

        #endregion

        #region Experiences

        List<Experience> GetExperiencesForAdmin();

        int AddExperience(Experience experience);

        Experience GetExperienceById(int experienceId);

        void UpdateExperience(Experience experience);

        Experience GetExperienceInformation(int experienceId);

        void DeleteExperience(int experienceId);

        #endregion

        #region Degrees

        List<Degree> GetDegreesForAdmin();

        int AddDegree(Degree degree);

        Degree GetDegreeById(int degreeId);

        void UpdateDegree(Degree degree);

        Degree GetDegreeInformation(int degreeId);

        void DeleteDegree(int degreeId);

        #endregion

        #region Projects

        List<ShowProjectsForAdminViewModel> GetProjectsForAdmin();

        int AddProject(Project project, IFormFile imgProject);

        Project GetProjectById(int projectId);

        void UpdateProject(Project project, IFormFile imgProject);

        void DeletProject(int projectId);

        ShowProjectsForAdminViewModel GetProjectInformation(int projectId);

        Tuple<List<ShowProjectListItemViewModel>, int> GetProjectList(int pageId = 1, int take = 0);
        #endregion

        #region Contact

        void AddContact(Contact contact);

        Tuple<List<Contact>, int> GetContactForAdmin(int pageId = 1, int take = 0);

        Contact GetContactById(int contactId);

        void DeleteContact(int contactId);

        int GetContactCount();

        #endregion

    }
}
