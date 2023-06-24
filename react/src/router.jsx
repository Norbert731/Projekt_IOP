import { createBrowserRouter } from "react-router-dom";
import Contacts from "./views/Contacts.jsx";
import NotFound from "./views/NotFound.jsx";
import Login from "./views/Login.jsx";
import Registration from "./views/Registration.jsx";

const router = createBrowserRouter([
  {
    path: "/",
    element: <Contacts />,
  },
  {
    path: "/login",
    element: <Login />,
  },
  {
    path: "/registration",
    element: <Registration />,
  },
  {
    path: "*",
    element: <NotFound />,
  },
]);

export default router;
