import React from 'react';
import { useLocation } from "react-router-dom";

function useQuery() {
    const { search } = useLocation();

    return React.useMemo(() => new URLSearchParams(search), [search]);
}

const Test = () => {
    const location = useLocation();
    let query = useQuery();

    let id = query.get("id");

    const querystr = require('query-string');
    const parsed = querystr.parse(location.search);
    console.log(parsed);

    return (
        <div>
            {id ? (
                <h3>
                    The <code>id</code> in the query string is &quot;{id}
                    &quot;
                </h3>
            ) : (
                <h3>There is no id in the query string</h3>
            )}
        </div>
    )
};

export default Test;