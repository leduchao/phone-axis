import AdbIcon from "@mui/icons-material/Adb";
import MenuIcon from "@mui/icons-material/Menu";
import { ROUTES } from "../routes";
import { useEffect, useState } from "react";
import { authApi } from "../apis/auth-api";
import { useNavigate } from "react-router";
import { userApi } from "../apis/user-api";
import { UserBasicInfo } from "../models/user-model";
import {
  AppBar,
  Avatar,
  Box,
  Button,
  Container,
  IconButton,
  Menu,
  MenuItem,
  Toolbar,
  Tooltip,
  Typography,
} from "@mui/material";

interface HeaderItem {
  key: number;
  name: string;
  href: string;
}

const pages: HeaderItem[] = [
  {
    key: 1,
    name: "Products",
    href: "/products",
  },
  {
    key: 2,
    name: "Pricing",
    href: "/pricing",
  },
  {
    key: 3,
    name: "Blogs",
    href: "/blogs",
  },
];
const settings = ["Profile", "Account", "Dashboard", "Logout"];

function Header() {
  const navigate = useNavigate();
  const [anchorElNav, setAnchorElNav] = useState<null | HTMLElement>(null);
  const [anchorElUser, setAnchorElUser] = useState<null | HTMLElement>(null);

  const [userInfo, setUserInfo] = useState<UserBasicInfo>({
    isAdmin: false,
    firstName: "",
    profilePicture: "",
  });

  const handleOpenNavMenu = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorElNav(event.currentTarget);
  };
  const handleOpenUserMenu = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorElUser(event.currentTarget);
  };

  const handleCloseNavMenu = () => {
    setAnchorElNav(null);
  };

  const goToPage = (href: string) => {
    handleCloseNavMenu();
    navigate(href);
  };

  const handleSignOut = () => {
    authApi.signOut();
    navigate(ROUTES.SignIn);
  };

  const handleCloseUserMenu = () => {
    setAnchorElUser(null);
  };

  const getUserBasicInfo = async () => {
    try {
      const result = await userApi.getUserBasicInfo();
      console.log(result);
      if (result.isSuccess && result.data)
        setUserInfo({
          isAdmin: result.data.isAdmin,
          firstName: result.data.firstName,
          profilePicture: result.data.profilePicture,
        });
    } catch (error) {
      console.error(error);
    }
  };

  useEffect(() => {
    getUserBasicInfo();
  }, []);

  return (
    <AppBar position="fixed" color="inherit">
      <Container maxWidth="xl">
        <Toolbar disableGutters>
          <AdbIcon sx={{ display: { xs: "none", md: "flex" }, mr: 1 }} />
          <Typography
            variant="h6"
            noWrap
            component="a"
            href={ROUTES.Home}
            sx={{
              mr: 2,
              display: { xs: "none", md: "flex" },
              fontFamily: "monospace",
              fontWeight: 700,
              color: "inherit",
              textDecoration: "none",
            }}
          >
            PHONEAXIS
          </Typography>

          <Box sx={{ flexGrow: 1, display: { xs: "flex", md: "none" } }}>
            <IconButton
              size="large"
              aria-label="account of current user"
              aria-controls="menu-appbar"
              aria-haspopup="true"
              onClick={handleOpenNavMenu}
              color="inherit"
            >
              <MenuIcon />
            </IconButton>
            <Menu
              id="menu-appbar"
              anchorEl={anchorElNav}
              anchorOrigin={{
                vertical: "bottom",
                horizontal: "left",
              }}
              keepMounted
              transformOrigin={{
                vertical: "top",
                horizontal: "left",
              }}
              open={Boolean(anchorElNav)}
              onClose={handleCloseNavMenu}
              sx={{ display: { xs: "block", md: "none" } }}
            >
              {pages.map((page) => (
                <MenuItem key={page.key} onClick={() => goToPage(page.href)}>
                  <Typography sx={{ textAlign: "center" }}>
                    {page.name}
                  </Typography>
                </MenuItem>
              ))}
            </Menu>
          </Box>
          <AdbIcon sx={{ display: { xs: "flex", md: "none" }, mr: 1 }} />
          <Typography
            variant="h5"
            noWrap
            component="a"
            href={`${ROUTES.Home}`}
            sx={{
              mr: 2,
              display: { xs: "flex", md: "none" },
              flexGrow: 1,
              fontFamily: "monospace",
              fontWeight: 700,
              color: "inherit",
              textDecoration: "none",
            }}
          >
            PHONEAXIS
          </Typography>
          <Box sx={{ flexGrow: 1, display: { xs: "none", md: "flex" } }}>
            {pages.map((page) => (
              <Button
                key={page.key}
                color="inherit"
                onClick={() => goToPage(page.href)}
                sx={{ my: 2, display: "block" }}
              >
                {page.name}
              </Button>
            ))}
          </Box>
          <Box sx={{ flexGrow: 0, display: "flex" }}>
            <Typography
              component={"span"}
              sx={{
                marginRight: "10px",
                alignContent: "center",
              }}
            >
              {userInfo.firstName}
            </Typography>
            <Tooltip title="Open settings">
              <IconButton onClick={handleOpenUserMenu} sx={{ p: 0 }}>
                <Avatar alt="Remy Sharp" src="/static/images/avatar/2.jpg" />
              </IconButton>
            </Tooltip>
            <Menu
              sx={{ mt: "45px" }}
              id="menu-appbar"
              anchorEl={anchorElUser}
              anchorOrigin={{
                vertical: "top",
                horizontal: "right",
              }}
              keepMounted
              transformOrigin={{
                vertical: "top",
                horizontal: "right",
              }}
              open={Boolean(anchorElUser)}
              onClose={handleCloseUserMenu}
            >
              {settings.map((setting) =>
                setting === settings[3] ? (
                  <MenuItem key={setting} onClick={handleSignOut}>
                    <Typography sx={{ textAlign: "center" }}>
                      {setting}
                    </Typography>
                  </MenuItem>
                ) : (
                  <MenuItem key={setting} onClick={handleCloseUserMenu}>
                    <Typography sx={{ textAlign: "center" }}>
                      {setting}
                    </Typography>
                  </MenuItem>
                )
              )}
            </Menu>
          </Box>
        </Toolbar>
      </Container>
    </AppBar>
  );
}

export default Header;
