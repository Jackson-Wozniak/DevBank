import { Alert } from "@mui/material";
import Snackbar from "@mui/material/Snackbar";

const ServerUnreachableSnackbar: React.FC<{
    open: boolean, 
    handleClose: () => void
}> = ({open, handleClose}) => {
    return (
        <Snackbar open={open} onClose={handleClose} autoHideDuration={5000} 
            anchorOrigin={{ vertical: "top", horizontal: "center" }}
        >
            <Alert onClose={handleClose} severity="error" sx={{ width: "100%" }}>
                Could not reach DevNote server. Please ensure it is running locally with the command "devnote browse"
            </Alert>
        </Snackbar>
    );
};

export default ServerUnreachableSnackbar;