import { createBrowserRouter } from "react-router-dom";
import Contacts from "./views/Contacts.jsx";
import NotFound from "./views/NotFound.jsx";

const router = createBrowserRouter([
  {
    path: "/",
    element: <Contacts />,
  },

  {
    path: "*",
    element: <NotFound />,
  },
]);

export default router;
