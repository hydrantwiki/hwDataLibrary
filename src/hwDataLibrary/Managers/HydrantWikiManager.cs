using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using HydrantWiki.Library.DAOs;
using HydrantWiki.Library.Enums;
using HydrantWiki.Library.Helpers;
using HydrantWiki.Library.Objects;
using TreeGecko.Library.AWS.Helpers;
using TreeGecko.Library.Common.Helpers;
using TreeGecko.Library.Common.Objects;
using TreeGecko.Library.Geospatial.Enums;
using TreeGecko.Library.Geospatial.Helpers;
using TreeGecko.Library.Geospatial.Objects;
using TreeGecko.Library.Mongo.Managers;
using TreeGecko.Library.Net.DAOs;
using TreeGecko.Library.Net.Helpers;
using TreeGecko.Library.Net.Interfaces;
using TreeGecko.Library.Net.Objects;

namespace HydrantWiki.Library.Managers
{
    public class HydrantWikiManager : AbstractMongoManager, IServerDataManager
    {

        public HydrantWikiManager()
            : base("HW")
        {
           
        }



        #region Users
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_user"></param>
        public void Persist(User _user)
        {
            UserDAO dao = new UserDAO(MongoDB);
            dao.Persist(_user);
        }

        public TGUser GetUser(Guid _userGuid)
        {
            UserDAO dao =new UserDAO(MongoDB);
            return dao.Get(_userGuid);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_userSource"></param>
        /// <param name="_username"></param>
        /// <returns></returns>
        public User GetUser(string _userSource, string _username)
        {
            UserDAO dao = new UserDAO(MongoDB);
            return dao.Get(_userSource, _username);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_userSource"></param>
        /// <param name="_emailAddress"></param>
        /// <returns></returns>
        public User GetUserByEmail(string _userSource, string _emailAddress)
        {
            UserDAO dao = new UserDAO(MongoDB);
            return dao.GetByEmail(_userSource, _emailAddress);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public long GetUserCount()
        {
            return 0;
        }

        #endregion

        #region Tags
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_tagGuid"></param>
        /// <returns></returns>
        public Tag GetTag(Guid _tagGuid)
        {
            TagDAO dao = new TagDAO(MongoDB);
            return dao.Get(_tagGuid);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public long GetTagCount()
        {
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_userName"></param>
        /// <returns></returns>
        public int GetActiveTagCount(string _userName)
        {
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_userName"></param>
        /// <returns></returns>
        public int GetInactiveTagCount(string _userName)
        {
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_tag"></param>
        public void Persist(Tag _tag)
        {
            TagDAO dao = new TagDAO(MongoDB);
            dao.Persist(_tag);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_hydrantGuid"></param>
        /// <returns></returns>
        public List<Tag> GetTags(Guid _hydrantGuid)
        {
            TagDAO dao = new TagDAO(MongoDB);
            return dao.GetTagsForHydrant(_hydrantGuid);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_userGuid"></param>
        /// <param name="_limit"></param>
        /// <param name="_startKey"></param>
        /// <returns></returns>
        public List<Tag> GetTagsForUser(Guid _userGuid, int _limit, string _startKey)
        {
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_userGuid"></param>
        /// <returns></returns>
        public List<Tag> GetTagsForUser(Guid _userGuid)
        {
            TagDAO dao = new TagDAO(MongoDB);
            return dao.GetTagsForUser(_userGuid);
        }

        public Tag GetNextPendingTag()
        {
            TagDAO dao = new TagDAO(MongoDB);
            return dao.GetNextPendingTag();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_tag"></param>
        public void DeleteTag(Tag _tag)
        {
            TagDAO dao = new TagDAO(MongoDB);
            dao.Delete(_tag);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_tagGuid"></param>
        public void DeleteTag(Guid _tagGuid)
        {
            TagDAO dao = new TagDAO(MongoDB);
            dao.Delete(_tagGuid);
        }

        #endregion

        #region Hydrant

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_hydrant"></param>
        public void Persist(Hydrant _hydrant)
        {
            HydrantDAO dao = new HydrantDAO(MongoDB);
            dao.Persist(_hydrant);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public long GetHydrantCount()
        {
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_userName"></param>
        /// <returns></returns>
        public int GetHydrantCount(string _userName)
        {
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_hydrant"></param>
        public void DeleteHydrant(Hydrant _hydrant)
        {
            HydrantDAO dao = new HydrantDAO(MongoDB);
            dao.Delete(_hydrant);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_hydrantGuid"></param>
        public void DeleteHydrant(Guid _hydrantGuid)
        {
            HydrantDAO dao = new HydrantDAO(MongoDB);
            dao.Delete(_hydrantGuid);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_hydrantGuid"></param>
        /// <returns></returns>
        public Hydrant GetHydrant(Guid _hydrantGuid)
        {
            HydrantDAO dao = new HydrantDAO(MongoDB);
            return dao.Get(_hydrantGuid);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_hydrant"></param>
        /// <param name="_newPosition"></param>
        /// <param name="_reviewerUserGuid"></param>
        public void UpdateHydrantPosition(Hydrant _hydrant,
            GeoPoint _newPosition, Guid _reviewerUserGuid)
        {
            _hydrant.Position = _newPosition;
            _hydrant.LastReviewerUserGuid = _reviewerUserGuid;
            _hydrant.LastModifiedDateTime = DateTime.UtcNow;

            Persist(_hydrant);
        }

        #endregion

        #region HydrantImage
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_hydrantImage"></param>
        public void Persist(HydrantImage _hydrantImage)
        {
            HydrantImageDAO dao = new HydrantImageDAO(MongoDB);
            dao.Persist(_hydrantImage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_hydrantGuid"></param>
        /// <param name="_imageGuid"></param>
        public void RemoveImageFromHydrant(Guid _hydrantGuid, Guid _imageGuid)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_hydrantGuid"></param>
        /// <returns></returns>
        public List<HydrantImage> GetHydrantImages(Guid _hydrantGuid)
        {
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_hydrantGuid"></param>
        public void DeleteHydrantImages(Guid _hydrantGuid)
        {

        }

        public void DeleteHydrantImage(Guid _hydrantGuid, Guid _imageGuid)
        {

        }

        #endregion


        #region Actions
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_tag"></param>
        /// <param name="_reviewerUserGuid"></param>
        /// <returns></returns>
        public Hydrant TagToNewHydrant(Tag _tag, Guid _reviewerUserGuid)
        {
            Hydrant hydrant = new Hydrant
            {
                Active = true,
                CreationDateTime = DateTime.Now,
                OriginalTagDateTime = _tag.DeviceDateTime,
                OriginalTagUserGuid = _tag.UserGuid,
                PrimaryImageGuid = _tag.ImageGuid,
                OriginalReviewerUserGuid = _reviewerUserGuid,
                LastReviewerUserGuid = _reviewerUserGuid,
                Position = _tag.Position
            };
            hydrant.LastModifiedDateTime = hydrant.CreationDateTime;

            foreach (Property property in _tag.Properties)
            {
                hydrant.Properties.SetValue(property.Name, property.Value, property.AttributeType);
            }

            Persist(hydrant);

            //Assign initial image to hydrant
            if (hydrant.PrimaryImageGuid != null)
            {
                AssignImageToHydrant(hydrant.Guid, hydrant.PrimaryImageGuid.Value);
            }

            //Assign tag to hydrant
            _tag.HydrantGuid = hydrant.Guid;

            //Add to Geospatial table
            Persist(_tag);

            return hydrant;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_hydrantGuid"></param>
        /// <param name="_imageGuid"></param>
        public void AssignImageToHydrant(Guid _hydrantGuid, Guid _imageGuid)
        {
            HydrantImage hi = new HydrantImage { 
                                                    HydrantGuid = _hydrantGuid, 
                                                    ImageGuid = _imageGuid 
                                               };

            Persist(hi);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_hydrant"></param>
        /// <param name="_tag"></param>
        /// <param name="_positionAction"></param>
        /// <param name="_reviewerUserGuid"></param>
        public void UpdateHydrantWithNewTag(Hydrant _hydrant,
                                            Tag _tag,
                                            TagPositionAction _positionAction,
                                            Guid _reviewerUserGuid)
        {
            bool needsSaving = false;

            if (_hydrant != null
                && _tag != null)
            {
                if (_tag.ImageGuid != null)
                {
                    if (_hydrant.PrimaryImageGuid == null)
                    {
                        _hydrant.PrimaryImageGuid = _tag.ImageGuid;
                        _hydrant.LastModifiedDateTime = DateTime.UtcNow;
                        _hydrant.LastReviewerUserGuid = _reviewerUserGuid;
                        needsSaving = true;
                    }

                    AssignImageToHydrant(_hydrant.Guid, _tag.ImageGuid.Value);
                }

                if (needsSaving)
                {
                    Persist(_hydrant);
                }
            }
        }

        #endregion

        #region Search

        public List<Hydrant> GetHydrants(GeoBox _geoBox)
        {
            HydrantDAO dao = new HydrantDAO(MongoDB);
            return dao.GetHydrants(_geoBox);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_tagPosition"></param>
        /// <returns></returns>
        public List<NearbyHydrant> GetNearbyHydrants(GeoPoint _tagPosition)
        {
            GeoDistance distance = new GeoDistance(DistanceUnits.Feet, 75);
            GeoBox gb = new GeoBox(_tagPosition, distance, distance);

            List<Hydrant> hydrants = GetHydrants(gb);

            List<NearbyHydrant> output = new List<NearbyHydrant>();

            foreach (Hydrant hydrant in hydrants)
            {
                NearbyHydrant nbh = new NearbyHydrant
                {
                    Position = hydrant.Position,
                    HydrantGuid = hydrant.Guid,
                    DistanceInFeet =
                        PositionHelper.GetDistance(_tagPosition, hydrant.Position).ToFeet().ToString("###.#"),
                    HydrantImageUrl = string.Format("http://{0}", hydrant.GetUrl(true))
                };

                output.Add(nbh);

            }

            return output;
        }

        #endregion



        /// <summary>
        /// 
        /// </summary>
        /// <param name="_username"></param>
        /// <param name="_activeOnly"></param>
        /// <param name="_maxRows"></param>
        /// <param name="_startKey"></param>
        /// <returns></returns>
        public List<TagRow> GetTagRows(string _username, bool _activeOnly, int _maxRows, 
            ref string _startKey)
        {
            return null;
        }

        //Gets all tags
        public List<TagRow> GetTagRows(string _username, bool _activeOnly)
        {
            try
            {
                string startKey = null;

                return GetTagRows(_username, _activeOnly, 0, ref startKey);
            }
            catch (Exception ex)
            {
                TraceFileHelper.Exception(ex);
            }

            return null;
        }

        #region UserStats

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_userStats"></param>
        public void Persist(UserStats _userStats)
        {
            UserStatsDAO dao = new UserStatsDAO(MongoDB);
            dao.Persist(_userStats);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_userGuid"></param>
        public void UserStats_AddHydrant(Guid _userGuid)
        {
            UserStats userStats = GetUserStats(_userGuid);

            userStats.HydrantCount++;

            Persist(userStats);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_userGuid"></param>
        public void UserStats_DeactivateTag(Guid _userGuid)
        {
            UserStats userStats = GetUserStats(_userGuid);

            userStats.ActiveTagCount--;

            Persist(userStats);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_userSource"></param>
        /// <param name="_userName"></param>
        public void UserStats_AddTag(string _userSource, string _userName)
        {
            UserStats userStats = GetUserStats(_userSource, _userName);

            userStats.TagCount++;
            userStats.ActiveTagCount++;

            Persist(userStats);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_userSource"></param>
        /// <param name="_username"></param>
        /// <returns></returns>
        public UserStats GetUserStats(string _userSource, string _username)
        {
            User user = GetUser(_userSource, _username);

            if (user != null)
            {
                return GetUserStats(user.Guid);
            }

            return null;
        }

        public UserStats GetUserStats(Guid _userGuid)
        {
            UserStatsDAO dao = new UserStatsDAO(MongoDB);
            return dao.GetByUser(_userGuid);
        }

        #endregion





        public bool ValidateUser(TGUser _user, string _testPassword)
        {
            TGUserPassword userPassword = GetTGUserPassword(_user.Guid);

            if (userPassword != null)
            {
                string testHash = TGUserPassword.HashPassword(userPassword.Salt, _testPassword);

                if (testHash.Equals(userPassword.HashedPassword))
                {
                    return true;
                }
            }

            return false;
        }

        public bool ValidateAuthorizationToken(Guid _userGuid, string _authorizationToken)
        {
            throw new NotImplementedException();
        }

        public TGUserPassword GetTGUserPassword(Guid _guid)
        {
            TGUserPasswordDAO dao = new TGUserPasswordDAO(MongoDB);
            return dao.Get(_guid);
        }

        public TGUserPassword GetUserPasswordByUser(Guid _userGuid)
        {
            TGUserPasswordDAO dao = new TGUserPasswordDAO(MongoDB);
            return dao.GetOneItem<TGUserPassword>("UserGuid", _userGuid.ToString());
        }

        public void Persist(TGUserPassword _userPassword)
        {
            TGUserPasswordDAO dao = new TGUserPasswordDAO(MongoDB);
            dao.Persist(_userPassword);
        }

        public TGUserEmailValidation GetTGUserEmailValidation(string _emailToken)
        {
            TGUserEmailValidationDAO dao = new TGUserEmailValidationDAO(MongoDB);
            return dao.Get(_emailToken);
        }

        public void Persist(TGUserEmailValidation _emailValidation)
        {
            TGUserEmailValidationDAO dao = new TGUserEmailValidationDAO(MongoDB);
            dao.Persist(_emailValidation);
        }

        public void SendUserValidationEmail(TGUser _tgUser, TGUserEmailValidation _tgUserEmailValidation)
        {
            
        }

        public bool SendCannedEmail(TGUser _tgUser, 
            string _cannedEmailName, 
            NameValueCollection _additionParameters)
        {
            try
            {
                CannedEmail cannedEmail = GetCannedEmail(_cannedEmailName);

                if (cannedEmail != null)
                {
                    SystemEmail email = new SystemEmail(cannedEmail.Guid);

                    TGSerializedObject tgso = _tgUser.GetTGSerializedObject();
                    foreach (string key in _additionParameters.Keys)
                    {
                        string value = _additionParameters.Get(key);
                        tgso.Add(key, value);
                    }

                    CannedEmailHelper.PopulateEmail(cannedEmail, email, tgso);

                    SESHelper.SendMessage(email);
                    Persist(email);

                    return true;
                }
                else
                {
                    TraceFileHelper.Warning("Canned email not found");
                }
            }
            catch (Exception ex)
            {
                TraceFileHelper.Exception(ex);
            }

            return false;

        }

        public void Delete(TGUserEmailValidation _emailValidation)
        {
            TGUserEmailValidationDAO dao = new TGUserEmailValidationDAO(MongoDB);
            dao.Delete(_emailValidation);
        }

        #region Email
        public void Persist(CannedEmail _cannedEmail)
        {
            CannedEmailDAO dao = new CannedEmailDAO(MongoDB);
            dao.Persist(_cannedEmail);
        }

        public CannedEmail GetCannedEmail(Guid _cannedEmailGuid)
        {
            CannedEmailDAO dao = new CannedEmailDAO(MongoDB);
            return dao.Get(_cannedEmailGuid);
        }

        public CannedEmail GetCannedEmail(string _cannedEmailName)
        {
            CannedEmailDAO dao = new CannedEmailDAO(MongoDB);
            return dao.Get(_cannedEmailName);
        }

        public void Persist(SystemEmail _systemEmail)
        {
            SystemEmailDAO dao = new SystemEmailDAO(MongoDB);
            dao.Persist(_systemEmail);
        }

        public SystemEmail GetSystemEmail(Guid _guid)
        {
            SystemEmailDAO dao = new SystemEmailDAO(MongoDB);
            return dao.Get(_guid);
        }

        #endregion

        #region UserAuthorizations

        public TGUserAuthorization GetUserAuthorization(Guid _userGuid, string _authorizationToken)
        {
            TGUserAuthorizationDAO dao = new TGUserAuthorizationDAO(MongoDB);
            return dao.Get(_userGuid, _authorizationToken);
        }

        public void Persist(TGUserAuthorization _tgUserAuthorization)
        {
            TGUserAuthorizationDAO dao = new TGUserAuthorizationDAO(MongoDB);
            dao.Persist(_tgUserAuthorization);
        }

        #endregion


        #region Logging
        public void LogWarning(Guid _userGuid, string _message)
        {
            WebLogEntryDAO dao = new WebLogEntryDAO(MongoDB);
            
        }

        public void LogException(Guid _userGuid, Exception _message)
        {
            
        }

        public void LogInfo(Guid _userGuid, string _message)
        {
            
        }

        public void LogVerbose(Guid _userGuid, string _message)
        {

        }

        #endregion

        #region images

        public void PersistOriginal(Guid _fileGuid, string _extension, 
            string _mimetype, byte[] _data)
        {
            string bucketName = Config.GetSettingValue("S3Bucket_Originals");
            string folderName = Config.GetSettingValue("S3MediaRootFolder");

            string filename = ImageProcessingHelper.GetPath(_fileGuid, folderName, _extension, false);

            S3Helper.PersistFile(bucketName, filename, _mimetype, _data);
        }

        public byte[] GetOriginal(Guid _fileGuid, string _extension)
        {
            string bucketName = Config.GetSettingValue("S3Bucket_Originals");
            string folderName = Config.GetSettingValue("S3MediaRootFolder");

            string filename = ImageProcessingHelper.GetPath(_fileGuid, folderName, _extension, false);

            return S3Helper.GetFile(bucketName, filename);
        }

        public void PersistWebImage(Guid _fileGuid, string _extension,
            string _mimetype, byte[] _data)
        {
            string bucketName = Config.GetSettingValue("S3Bucket_Images");
            string folderName = Config.GetSettingValue("S3MediaRootFolder");

            string filename = ImageProcessingHelper.GetPath(_fileGuid, folderName, _extension, false);

            S3Helper.PersistFile(bucketName, filename, _mimetype, _data);
        }

        public byte[] GetWebImage(Guid _fileGuid, string _extension)
        {
            string bucketName = Config.GetSettingValue("S3Bucket_Images");
            string folderName = Config.GetSettingValue("S3MediaRootFolder");

            string filename = ImageProcessingHelper.GetPath(_fileGuid, folderName, _extension, false);

            return S3Helper.GetFile(bucketName, filename);
        }

        public void PersistThumbnailImage(Guid _fileGuid, string _extension,
            string _mimetype, byte[] _data)
        {
            string bucketName = Config.GetSettingValue("S3Bucket_Images");
            string folderName = Config.GetSettingValue("S3MediaRootFolder");

            string filename = ImageProcessingHelper.GetPath(_fileGuid, folderName, _extension, true);

            S3Helper.PersistFile(bucketName, filename, _mimetype, _data);
        }

        public byte[] GetThumbnailImage(Guid _fileGuid, string _extension)
        {
            string bucketName = Config.GetSettingValue("S3Bucket_Images");
            string folderName = Config.GetSettingValue("S3MediaRootFolder");

            string filename = ImageProcessingHelper.GetPath(_fileGuid, folderName, _extension, true);

            return S3Helper.GetFile(bucketName, filename);
        }

        #endregion
    }
}
