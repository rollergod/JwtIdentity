import { useLocation } from "react-router-dom";


export const useQuery = () => {
    const location = useLocation();
    const queryString = require('query-string');
    let { userId, code } = queryString.parse(location.search);

    return { userId, code };
}
