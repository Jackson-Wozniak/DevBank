import { useEffect, useState } from "react";
import DevNote from "./components/DevNote"
import { fetchServerCheck } from "./api/DevNoteClient";
import ServerUnreachableSnackbar from "./components/shared/ServerUnreachableSnackbar";

function App() {
    const [showServerUnreachableError, setShowServerUnreachableError] = useState<boolean>(false);

    useEffect(() => {
        const fetchServerHealth = async () => {
            const isReachable = await fetchServerCheck();
            if(!isReachable) handleServerError();
        }

        fetchServerHealth();
    }, []);

    function handleServerError(){
        setShowServerUnreachableError(true);
    }

    return (
        <>
            <DevNote handleServerError={handleServerError}/>
            <ServerUnreachableSnackbar open={showServerUnreachableError} handleClose={() => setShowServerUnreachableError(false)}/>
        </>
    )
}

export default App
