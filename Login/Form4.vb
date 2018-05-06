Imports MySql.Data.MySqlClient
Public Class Form4
    Private Sub Pegawai_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call tampilPegawai()
    End Sub
    Sub bersihkan()
        txtId.Text = ""
        txtNama.Text = ""
        txtJabatan.Text = ""
        txtNoHp.Text = ""
    End Sub
    Sub tampilPegawai()
        Try
            Call koneksi()
            da = New MySqlDataAdapter("select * from datapegawai order by id_pegawai Asc", conn)
            ds = New DataSet
            da.Fill(ds, "datapegawai")
            dgvPegawai.DataSource = ds.Tables("datapegawai")
        Catch ex As Exception

        End Try
    End Sub
    Sub simpanPegawai()
        Try
            Call koneksi()
            Dim str As String
            str = "insert into datapegawai ( id_pegawai, nama, jabatan, nohp) values ('" & txtId.Text & "','" & txtNama.Text & "','" & txtJabatan.Text & "','" & txtNoHp.Text & "')"
            cmd = New MySqlCommand(str, conn)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Data Pegawai Berhasil Ditambahkan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Insert Data Pegawai Baru Gagal Dilakukan" + ex.Message, "Informasi", MessageBoxButtons.OK)
        End Try
    End Sub
    Sub ubahPegawai()
        Try
            Call koneksi()
            Dim str As String
            str = "update datapegawai set nama = '" & txtNama.Text & "', jabatan = '" & txtJabatan.Text & "', nohp = '" & txtNoHp.Text & "' where id_pegawai =  '" & txtId.Text & "'"
            cmd = New MySqlCommand(str, conn)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Data Pegawai Berhasil Diubah", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Ubah Data Pegawai Gagal Dilakukan" + ex.Message, "Informasi", MessageBoxButtons.OK)
        End Try
    End Sub
    Sub hapus()
        Try
            Call koneksi()
            Dim str As String
            str = "delete from datapegawai where id_pegawai ='" & txtId.Text & "'"
            cmd = New MySqlCommand(str, conn)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Data Pegawai Berhasil Dihapus", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Data Pegawa Gagal Dihapus" + ex.Message, "Informasi", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form2.Visible = True
        Form2.Enabled = True
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MessageBox.Show("Yakin ingin menyimpan data jabatan", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Call simpanPegawai()
            Call bersihkan()
            Call tampilPegawai()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MessageBox.Show("Yakin ingin mengubah data barang", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Call ubahPegawai()
            Call bersihkan()
            Call tampilPegawai()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If MessageBox.Show("Yakin Ingin Menghapus Data Jabatan?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Call hapus()
            Call bersihkan()
            Call tampilPegawai()
        End If
    End Sub
    Private Sub dgvPegawai_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPegawai.CellContentClick
        Try
            txtId.Text = dgvPegawai.Rows(e.RowIndex).Cells(0).Value
            txtNama.Text = dgvPegawai.Rows(e.RowIndex).Cells(1).Value
            txtJabatan.Text = dgvPegawai.Rows(e.RowIndex).Cells(2).Value
            txtNoHp.Text = dgvPegawai.Rows(e.RowIndex).Cells(3).Value

        Catch ex As Exception

        End Try
    End Sub
End Class