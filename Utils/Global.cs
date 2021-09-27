 

namespace Utils
{
    public static class Global
    {
        //public static string projectFolderPath { set; get; }
        //public static string wwwRootPath = "wwwroot";
        //public static string AttachmentFilesPath = "filesUploaded";

        public const byte allOk = 1;
        public const byte postStateNotValid = 2;
        //public const byte ipadNotEditableState = 3;
        //public const byte ipadhasEventsRelated = 4;

        //public const byte notValidCredentials = 20;
        //public const byte entryNotAllowed = 21;
        //public const byte entryAllowed = 22;
        //public const byte userLockedOut = 23;

        //public const string rolAdministrator = "ConEvIpAdministrator";
        //public const string rolTechSupport = "ConEvIpTechSupport";
        //public const string rolViewOnly = "ConEvIpReadOnly";

        //public const string errorInsertarDatos = "Ha ocurrido un error al guardar los datos";
        //public const string errorActualizarDatos = "Ha ocurrido un error al actualizar los datos";
        //public const string errorEliminarDatos = "Ha ocurrido un error al actualizar los datos";
        //public const string errorEnviarCorreo = "Ha ocurrido al enviar un correo";
        //public const string errorObtenerDatos = "Ha ocurrido al obtener los datos";
        //public const string errorValidacion = "Ha ocurrido un error de validación ";   

        public const byte postPublished = 1;
        public const byte postPending = 2;
        public const byte postRejected = 3;
        public const byte postOnEdition = 4;

        public static bool IsStateValidToSend(int stateId)
        {
            if (stateId == postPublished || stateId == postPending || stateId == postRejected )
            {
                return false;
            }
            else
            {
                return true;
            }

        }


        public static bool IsStateValidToReview(int stateId)
        {
            if (stateId == postPublished || stateId == postRejected || stateId == postOnEdition)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public static bool IsStateValidToDelete(int stateId)
        {
            if (stateId == postPublished || stateId == postPending)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public static bool IsStateValidToEdit(int stateId)
        {
            if (stateId == postPublished || stateId == postPending)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
