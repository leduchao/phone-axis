import MenuIcon from "@mui/icons-material/Menu";
import { ROUTES } from "../routes";
import { useState } from "react";
import { useNavigate } from "react-router";
import {
  AppBar,
  Box,
  Container,
  IconButton,
  InputAdornment,
  Link,
  Menu,
  MenuItem,
  TextField,
  Toolbar,
  Tooltip,
  Typography,
} from "@mui/material";
import {
  Clear,
  PersonOutlineOutlined,
  Search,
  ShoppingCartOutlined,
} from "@mui/icons-material";

interface HeaderItem {
  key: number;
  name: string;
  href: string;
}

const pages: HeaderItem[] = [
  {
    key: 1,
    name: "Shop",
    href: "/products",
  },
  {
    key: 2,
    name: "Categories",
    href: "/categories",
  },
  {
    key: 3,
    name: "About us",
    href: "/about-us",
  },
  {
    key: 4,
    name: "Blogs",
    href: "/blogs",
  },
  {
    key: 5,
    name: "Reviews",
    href: "/reviews",
  },
  {
    key: 6,
    name: "Contact us",
    href: "/contact-us",
  },
];

function Header() {
  const navigate = useNavigate();
  const [anchorElNav, setAnchorElNav] = useState<null | HTMLElement>(null);
  const [searchValue, setSearchValue] = useState("");

  const handleOpenNavMenu = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorElNav(event.currentTarget);
  };

  const handleCloseNavMenu = () => {
    setAnchorElNav(null);
  };

  const goToPage = (href: string) => {
    handleCloseNavMenu();
    navigate(href);
  };

  const handleSearch = () => {
    alert(`searching for ${searchValue}`);
  };

  return (
    <AppBar position="fixed" color="inherit">
      <Container maxWidth="xl">
        <Toolbar disableGutters={true}>
          <Typography
            variant="h4"
            noWrap
            component="a"
            href={ROUTES.Home}
            sx={{
              mr: { sm: 1, md: 3, lg: 12 },
              display: { xs: "none", md: "flex" },
              fontFamily: "monospace",
              fontWeight: 400,
              color: "black",
              textDecoration: "none",
            }}
          >
            PhoneAxis
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
              <Box sx={{ pl: 2, mt: 1 }}>
                <TextField
                  value={searchValue}
                  variant="outlined"
                  label="Search"
                  size="small"
                  sx={{ mr: 2 }}
                  onChange={(e) => setSearchValue(e.target.value)}
                  slotProps={{
                    input: {
                      endAdornment: (
                        <InputAdornment position="end">
                          {searchValue && (
                            <IconButton onClick={() => setSearchValue("")}>
                              <Clear />
                            </IconButton>
                          )}
                          <IconButton
                            aria-label="search"
                            onClick={handleSearch}
                            edge="end"
                          >
                            <Search />
                          </IconButton>
                        </InputAdornment>
                      ),
                    },
                  }}
                  onKeyDown={(e) => {
                    if (e.key === "Enter") {
                      handleSearch();
                    }
                  }}
                />
              </Box>

              <Box
                sx={{
                  px: 1,
                  mt: 1,
                  display: "flex",
                  justifyContent: "space-around",
                }}
              >
                <Tooltip title="Profile">
                  <IconButton
                    sx={{ mr: 1 }}
                    size="small"
                    color="inherit"
                    onClick={() => goToPage(ROUTES.SignIn)}
                  >
                    <PersonOutlineOutlined />
                  </IconButton>
                </Tooltip>

                <Tooltip title="Cart">
                  <IconButton size="small" color="inherit">
                    <ShoppingCartOutlined />
                  </IconButton>
                </Tooltip>
              </Box>
            </Menu>
          </Box>

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
            PhoneAxis
          </Typography>

          <Box sx={{ flexGrow: 1, display: { xs: "none", md: "flex" } }}>
            {pages.map((page) => (
              <Link
                key={page.key}
                href={page.href}
                sx={{ mx: { md: 1, lg: 2 }, color: "black" }}
                underline="hover"
              >
                {page.name}
              </Link>
            ))}
          </Box>

          <Box sx={{ flexGrow: 0, display: { xs: "none", md: "flex" } }}>
            <TextField
              value={searchValue}
              variant="outlined"
              label="Search"
              size="small"
              sx={{ mr: 2 }}
              onChange={(e) => setSearchValue(e.target.value)}
              slotProps={{
                input: {
                  endAdornment: (
                    <InputAdornment position="end">
                      {searchValue && (
                        <IconButton onClick={() => setSearchValue("")}>
                          <Clear />
                        </IconButton>
                      )}
                      <IconButton
                        aria-label="search"
                        onClick={handleSearch}
                        edge="end"
                      >
                        <Search />
                      </IconButton>
                    </InputAdornment>
                  ),
                },
              }}
              onKeyDown={(e) => {
                if (e.key === "Enter") {
                  handleSearch();
                }
              }}
            />

            <Tooltip title="Profile">
              <IconButton
                sx={{ mr: 1 }}
                size="small"
                color="inherit"
                onClick={() => goToPage(ROUTES.SignIn)}
              >
                <PersonOutlineOutlined />
              </IconButton>
            </Tooltip>

            <Tooltip title="Cart">
              <IconButton size="small" color="inherit">
                <ShoppingCartOutlined />
              </IconButton>
            </Tooltip>
          </Box>
        </Toolbar>
      </Container>
    </AppBar>
  );
}

export default Header;
